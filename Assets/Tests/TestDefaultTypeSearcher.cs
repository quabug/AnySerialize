using System;
using System.Linq;
using AnySerialize.CodeGen;
using Mono.Cecil;
using NUnit.Framework;
using UnityEditor;

namespace AnySerialize.Tests
{
    public class TestDefaultTypeSearcher : CecilTestBase
    {
        private DefaultTypeSearcher _searcher;
        private TypeTree _typeTree;
        
        protected override void OnSetUp()
        {
            var serializerTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(type => typeof(IAny).IsAssignableFrom(type))
            ;
            _typeTree = new TypeTree(serializerTypes.Select(type => ImportReference(type).Resolve()));
            _searcher = new DefaultTypeSearcher();
        }

        [Test]
        public void should_find_replace_type_for_primitive_type()
        {
            AssertTypeEqual(_searcher.Search(_typeTree, CreateProperty<int>()), ImportReference(typeof(AnyValue_Int32)));
            AssertTypeEqual(_searcher.Search(_typeTree, CreateProperty<float>()), ImportReference(typeof(AnyValue_Single)));
            AssertTypeEqual(_searcher.Search(_typeTree, CreateProperty<long>()), ImportReference(typeof(AnyValue_Int64)));
        }

        class A
        {
            public int ReadWriteField;
            public readonly int ReadOnlyField;
            public float ReadWriteProperty { get; set; }
            public float ReadOnlyProperty { get; }
        }
        
        [Test]
        public void should_find_replace_type_for_class_type()
        {
            var type = _searcher.Search(_typeTree, CreateProperty<A>());
            AssertTypeEqual(type, ImportReference(typeof(ReadOnlyAnyClass<A, int, AnyValue<int>, int, AnyValue<int>, float, AnyValue<float>, float, AnyValue<float>>)));
        }

        private PropertyDefinition CreateProperty<T>(Type searchingBaseType = null, string propertyName = "test")
        {
            var propertyType = ImportReference(typeof(T));
            var property = new PropertyDefinition(propertyName, PropertyAttributes.None, propertyType);
            property.DeclaringType = propertyType.Resolve();
            var attribute = property.AddCustomAttribute<AnySerializeAttribute>(_module, typeof(Type));
            attribute.ConstructorArguments.Add(new CustomAttributeArgument(ImportReference(typeof(Type)), searchingBaseType));
            return property;
        }
    }
}