using System;
using System.Collections.Generic;
using System.Linq;
using AnyProcessor.CodeGen;
using AnyProcessor.Tests;
using AnySerialize.CodeGen;
using Mono.Cecil;
using NUnit.Framework;
using OneShot;

namespace AnySerialize.Tests
{
    public class TestDefaultTypeSearcher : CecilTestBase
    {
        private SerializeTypeSearcher _searcher;
        private TypeTree _typeTree;
        private Container _container;

        protected override void OnSetUp()
        {
            var serializerTypes = typeof(IAny).Assembly.GetTypes()
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
            container.RegisterInstance(_module).AsSelf();
            return container.FindClosestType(target);
        }

        [Test]
        public void should_find_replace_type_for_primitive_type()
        {
            AssertTypeEqual<AnyValue_Int32>(SearchReadOnly<int>());
            AssertTypeEqual<AnyValue_Single>(SearchReadOnly<float>());
            AssertTypeEqual<AnyValue_Int64>(SearchReadOnly<long>());
        }

        [AnySerializable]
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
        public void should_find_replace_type_for_array_type()
        {
            AssertTypeEqual<AnyArray_Int32>(SearchReadOnly<int[]>());
        }
        
        [Test]
        public void should_find_replace_type_for_2D_array_type()
        {
            AssertTypeEqual<ReadOnlyAnyArray<int[], AnyArray_Int32>>(SearchReadOnly<int[][]>());
        }
        
        [Test]
        public void should_find_replace_type_for_3D_array_type()
        {
            AssertTypeEqual<ReadOnlyAnyArray<int[][], ReadOnlyAnyArray<int[], AnyArray_Int32>>>(SearchReadOnly<int[][][]>());
        }
        
        [Test, Ignore("not support yet")]
        public void should_find_replace_type_for_array_type_with_rank()
        {
            SearchReadOnly<int[,]>();
        }
        
        [Test]
        public void should_find_replace_type_for_dictionary_type()
        {
            AssertTypeEqual<ReadOnlyAnyDictionary<int, long, ReadOnlyAnyClass<AnyKeyValuePair<int, long>, int, long, AnyValue_Int32, AnyValue_Int64>>>(SearchReadOnly<Dictionary<int, long>>());
        }
        
        [Test]
        public void should_find_replace_type_for_lazy_type()
        {
            AssertTypeEqual<ReadOnlyAnyLazy<int, AnyValue_Int32>>(SearchReadOnly<Lazy<int>>());
        }
        
        [Test]
        public void should_find_replace_type_for_nullable_int()
        {
            AssertTypeEqual<ReadOnlyAnyNullableStruct<int, AnyValue_Int32>>(SearchReadOnly<int?>());
        }
        
#if UNITY_EDITOR
        [Test]
        public void should_find_replace_type_for_gameobject()
        {
            AssertTypeEqual<AnyValue_Object<UnityEngine.GameObject>>(SearchReadOnly<UnityEngine.GameObject>());
        }
        
        [Test]
        public void should_find_replace_type_for_gameobject_array()
        {
            AssertTypeEqual<AnyArray_Object<UnityEngine.GameObject>>(SearchReadOnly<UnityEngine.GameObject[]>());
        }
        
        [Test]
        public void should_find_replace_type_for_gameobject_array2()
        {
            AssertTypeEqual<ReadOnlyAnyArray<UnityEngine.GameObject[], AnyArray_Object<UnityEngine.GameObject>>>(SearchReadOnly<UnityEngine.GameObject[][]>());
        }
#endif
    }
}