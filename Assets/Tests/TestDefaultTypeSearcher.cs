using System;
using System.Linq;
using AnyProcessor.CodeGen;
using AnySerialize;
using AnySerialize.CodeGen;
using NUnit.Framework;

namespace AnyProcessor.Tests
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
            _searcher = new DefaultTypeSearcher(_typeTree, _module);
        }

        [Test]
        public void should_find_replace_type_for_primitive_type()
        {
            AssertTypeEqual(_searcher.Search(ImportReference<IReadOnlyAny<int>>()), ImportReference(typeof(AnyValue_Int32)));
            AssertTypeEqual(_searcher.Search(ImportReference<IReadOnlyAny<float>>()), ImportReference(typeof(AnyValue_Single)));
            AssertTypeEqual(_searcher.Search(ImportReference<IReadOnlyAny<long>>()), ImportReference(typeof(AnyValue_Int64)));
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
            var type = _searcher.Search(ImportReference<IReadOnlyAny<A>>());
            AssertTypeEqual(type, ImportReference(typeof(ReadOnlyAnyClass<A, int, int, float, float, AnyValue_Int32, AnyValue_Int32, AnyValue_Single, AnyValue_Single>)));
        }
    }
}