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

        private TypeReference SearchReadOnly<T>()
        {
            var target = ImportReference(typeof(IReadOnlyAny<T>));
            Assert.IsTrue(target is GenericInstanceType genericTarget && genericTarget.GenericArguments.Count == 1);
            var container = _container.CreateChildContainer();
            container.RegisterInstance(container).AsSelf();
            container.RegisterInstance(((GenericInstanceType)target).GenericArguments[0]).AsSelf(typeof(OuterLabel<>)).AsBases(typeof(OuterLabel<>));
            container.RegisterInstance(target).AsSelf(typeof(TargetLabel<>)).AsBases(typeof(TargetLabel<>));
            return container.Instantiate<SerializeTypeSearcher>().Search();
        }

        [Test]
        public void should_find_replace_type_for_primitive_type()
        {
            AssertTypeEqual<AnyValue_Int32>(SearchReadOnly<int>());
            AssertTypeEqual<AnyValue_Single>(SearchReadOnly<float>());
            AssertTypeEqual<AnyValue_Int64>(SearchReadOnly<long>());
        }

        class A
        {
            public int ReadWriteField;
            public readonly int ReadOnlyField;
            public float ReadWriteProperty { get; set; }
            public float ReadOnlyProperty { get; }
        }
        
        [Test]
        public void should_find_replace_type_for_simple_class_type()
        {
            AssertTypeEqual<ReadOnlyAnyClass<A, int, int, float, float, AnyValue_Int32, AnyValue_Int32, AnyValue_Single, AnyValue_Single>>(SearchReadOnly<A>());
        }
        
        [Test]
        public void should_find_replace_type_for_array_types()
        {
            AssertTypeEqual<AnyArray_Int32>(SearchReadOnly<int[]>());
            AssertTypeEqual<ReadOnlyAnyArray<int[], AnyArray_Int32>>(SearchReadOnly<int[][]>());
            AssertTypeEqual<ReadOnlyAnyArray<int[][], ReadOnlyAnyArray<int[], AnyArray_Int32>>>(SearchReadOnly<int[][]>());
        }
    }
}