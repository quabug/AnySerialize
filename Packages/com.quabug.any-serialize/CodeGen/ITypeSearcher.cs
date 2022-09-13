using System;
using System.Collections.Generic;
using System.Linq;
using AnyProcessor.CodeGen;
using JetBrains.Annotations;
using Mono.Cecil;
using OneShot;

namespace AnySerialize.CodeGen
{
    public interface ITypeSearcher
    {
        [CanBeNull] TypeReference Search();
    }
    
    public interface ITypeSearcher<T> : ITypeSearcher where T : Attribute, IAnyTypeSearcherAttribute {}

    public static class AnySearchers
    {
        private static readonly IReadOnlyDictionary<string /*attribute*/, Type /*searcher*/> _value;

        static AnySearchers()
        {
            var searchers = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where !type.IsAbstract
                from @base in type.GetSelfAndAllBases()
                from @interface in @base.GetInterfaces()
                where @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(ITypeSearcher<>)
                select (searcher: type, attribute: @interface.GenericTypeArguments[0])
            ;
            _value = searchers.ToDictionary(t => t.attribute.FullName, t => t.searcher);
        }

        public static TypeReference Search(this Container container, CustomAttribute attribute, params object[] instances)
        {
            return container.CreateSearcher(attribute, instances.Select(instance => (instance, (Type)null))).Search();
        }

        public static TypeReference Search(this Container container, CustomAttribute attribute, params (object instance, Type label)[] instances)
        {
            return container.CreateSearcher(attribute, instances).Search();
        }
        
        public static TypeReference Search<T>(this Container container) where T : ITypeSearcher
        {
            return container.CreateSearcher(typeof(T), Enumerable.Empty<(object instance, Type label)>()).Search();
        }
        
        public static TypeReference Search<T>(this Container container, params object[] instances) where T : ITypeSearcher
        {
            return container.CreateSearcher(typeof(T), instances.Select(instance => (instance, (Type)null))).Search();
        }

        public static TypeReference Search<T>(this Container container, params (object instance, Type label)[] instances) where T : ITypeSearcher
        {
            return container.CreateSearcher(typeof(T), instances).Search();
        }

        private static ITypeSearcher CreateSearcher(this Container container, CustomAttribute attribute, IEnumerable<(object instance, Type label)> instances)
        {
            var searcher = _value[attribute.AttributeType.FullName];
            container = container.CreateChildContainer();
            container.RegisterInstance(container).AsSelf();
            
            foreach (var attributeArgument in attribute.ConstructorArguments) container.RegisterInstance(attributeArgument.Value)
                .AsSelf(typeof(AttributeLabel<>))
                .AsBases(typeof(AttributeLabel<>))
                .AsInterfaces(typeof(AttributeLabel<>))
            ;
            
            foreach (var (instance, label) in instances) container.RegisterInstance(instance).AsSelf(label).AsBases(label).AsInterfaces(label);
            return (ITypeSearcher)container.Instantiate(searcher);
        }
        
        private static ITypeSearcher CreateSearcher(this Container container, Type searcherType, IEnumerable<(object instance, Type label)> instances)
        {
            container = container.CreateChildContainer();
            foreach (var (instance, label) in instances) container.RegisterInstance(instance).AsSelf(label).AsBases().AsInterfaces();
            return (ITypeSearcher)container.Instantiate(searcherType);
        }
    }
}