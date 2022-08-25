using System;
using System.Linq;
using AnyProcessor.CodeGen;
using AnySerialize;
using AnySerialize.CodeGen;
using Mono.Cecil;
using NUnit.Framework;
using OneShot;

namespace AnyProcessor.Tests
{
    public class TestDefaultTypeSearcher : CecilTestBase
    {
        private SerializeTypeSearcher _searcher;
        private TypeTree _typeTree;
        private Container _container;
        
        protected override void OnSetUp()
        {
            var serializerTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(type => typeof(IAny).IsAssignableFrom(type))
            ;
            _typeTree = new TypeTree(serializerTypes.Select(type => ImportReference(type).Resolve()));
            
            _container = new Container();
            _container.RegisterInstance(_assemblyDefinition).AsSelf();
            _container.RegisterInstance(new ILPostProcessorLogger()).AsSelf();
            _container.RegisterInstance(_module).AsSelf();
            _container.RegisterInstance(_typeTree).AsSelf();
        }

        protected override void OnTearDown()
        {
            _container.Dispose();
        }

        private SerializeTypeSearcher CreateSearcher(TypeReference target)
        {
            Assert.IsTrue(target is GenericInstanceType genericTarget && genericTarget.GenericArguments.Count == 1);
            var container = _container.CreateChildContainer();
            container.RegisterInstance(container).AsSelf();
            container.RegisterInstance(((GenericInstanceType)target).GenericArguments[0]).AsSelf(typeof(OuterLabel<>)).AsBases(typeof(OuterLabel<>));
            container.RegisterInstance(target).AsSelf(typeof(TargetLabel<>)).AsBases(typeof(TargetLabel<>));
            return container.Instantiate<SerializeTypeSearcher>();
        }

        [Test]
        public void should_find_replace_type_for_primitive_type()
        {
            AssertTypeEqual<AnyValue_Int32>(CreateSearcher(ImportReference<IReadOnlyAny<int>>()).Search());
            AssertTypeEqual<AnyValue_Single>(CreateSearcher(ImportReference<IReadOnlyAny<float>>()).Search());
            AssertTypeEqual<AnyValue_Int64>(CreateSearcher(ImportReference<IReadOnlyAny<long>>()).Search());
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
            var type = CreateSearcher(ImportReference<IReadOnlyAny<A>>()).Search();
            AssertTypeEqual<ReadOnlyAnyClass<A, int, int, float, float, AnyValue_Int32, AnyValue_Int32, AnyValue_Single, AnyValue_Single>>(type);
        }
    }
}