using System;
using System.Linq;
using System.Runtime.Serialization;
using AnySerialize.CodeGen;
using Mono.Cecil;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AnySerialize.Tests
{
    public class TestCecil : CecilTestBase
    {
        [Test]
        public void should_resolve_unity_type()
        {
            var type = ImportReference<ExitPlayMode>().Resolve();
            Assert.AreEqual(1, type.Interfaces.Count);
            var interfaceReference = type.Interfaces.First();
            Assert.NotNull(interfaceReference);
            Assert.NotNull(interfaceReference.InterfaceType);
            Assert.NotNull(interfaceReference.InterfaceType.Resolve());
        }

        [Test]
        public void should_get_generic_type_definition_from_generic_type()
        {
            var typeDef = ImportReference<MultipleGeneric.IInterface<int, int>>().Resolve();
            Assert.NotNull(typeDef);
        }

        [Test]
        public void should_resolve_generic_types_in_another_assembly()
        {
            var typeRef = ImportReference<AnotherAssembly.IGeneric<int,int>>();
            Debug.Log($"{typeRef} {typeRef.Module}");
            Assert.NotNull(typeRef);
            Assert.NotNull(typeRef.Resolve());
        }

        [Test]
        public void should_resolve_types_in_another_assembly()
        {
            var typeRef = ImportReference<AnotherAssembly>();
            Debug.Log($"{typeRef} {typeRef.Module}");
            Assert.NotNull(typeRef);
            Assert.NotNull(typeRef.Resolve());
        }

        class AnotherGeneric : AnotherAssembly.Generic {}

        [Test]
        public void should_resolve_types_inherited_from_another_assembly()
        {
            var typeRef = ImportReference<AnotherGeneric>();
            Debug.Log($"{typeRef} {typeRef.Module}");
            Assert.NotNull(typeRef);
            Assert.NotNull(typeRef.Resolve());

            var baseType = typeRef.Resolve().BaseType;
            Debug.Log($"{baseType} {baseType.Module}");
            Assert.NotNull(baseType);
            Assert.NotNull(baseType.Resolve());
        }

        [Test]
        public void should_resolve_types_in_system_assembly()
        {
            var typeRef = ImportReference<Attribute>();
            Debug.Log($"{typeRef} {typeRef.Module}");
            Assert.NotNull(typeRef);
            Assert.NotNull(typeRef.Resolve());
        }

        [Serializable]
        public class GenericTypeNotMatchException : Exception
        {
            public GenericTypeNotMatchException() { }
            public GenericTypeNotMatchException( string message ) : base( message ) { }
            public GenericTypeNotMatchException( string message, Exception inner ) : base( message, inner ) { }
            protected GenericTypeNotMatchException(SerializationInfo info, StreamingContext context ) : base( info, context ) { }
        }

        class Generic<T1, T2, T3, T4> {}
        class IntPartial<T1, T2, T3, T4> : Generic<T2, T3, T1, T4> {}
        class IntPartial<T1, T2, T3> : Generic<T2, T1, T3, int> {}
        class IntPartial<T1, T3> : Generic<T3, int, T1, int> {}
        class IntPartial : Generic<int, int, int, int> {}

        class IntFloatPartial : Generic<int, float, float, int> {}
        class IntFloatPartial<T1> : Generic<T1, float, float, int> {}
        class IntFloatPartial<T1, T2> : Generic<int, float, T1, T2> {}
        class IntFloatPartial<T1, T2, T3> : Generic<T1, float, T3, T2> {}

        [Test]
        public void should_check_whether_or_not_a_partial_type_is_match_to_a_concrete_generic_type()
        {
            var intGeneric = (GenericInstanceType)ImportReference(typeof(Generic<int, int, int, int>));

            var intPartial = (GenericInstanceType)ImportReference(typeof(IntPartial)).Resolve().BaseType;
            var intPartial2 = (GenericInstanceType)ImportReference(typeof(IntPartial<,>)).Resolve().BaseType;
            var intPartial3 = (GenericInstanceType)ImportReference(typeof(IntPartial<,,>)).Resolve().BaseType;

            Assert.IsTrue(CecilExtension.IsPartialGenericMatch(intPartial, intGeneric));
            Assert.IsTrue(CecilExtension.IsPartialGenericMatch(intPartial2, intGeneric));
            Assert.IsTrue(CecilExtension.IsPartialGenericMatch(intPartial3, intGeneric));

            var intFloatPartial = (GenericInstanceType)ImportReference(typeof(IntFloatPartial)).Resolve().BaseType;
            var intFloatPartial2 = (GenericInstanceType)ImportReference(typeof(IntFloatPartial<,>)).Resolve().BaseType;

            Assert.IsFalse(CecilExtension.IsPartialGenericMatch(intFloatPartial, intGeneric));
            Assert.IsFalse(CecilExtension.IsPartialGenericMatch(intFloatPartial2, intGeneric));
        }

        // [Test]
        // public void should_resolve_generic_arguments()
        // {
        //     var genericBase = (GenericInstanceType)ImportReference(typeof(Generic<float, int, double, int>));
        //
        //     var intPartial1 = ImportReference(typeof(IntPartial)).Resolve();
        //     var intPartial2 = ImportReference(typeof(IntPartial<,>)).Resolve();
        //     var intPartial3 = ImportReference(typeof(IntPartial<,,>)).Resolve();
        //
        //     // cannot match
        //     Assert.Throws<InvalidOperationException>(() => intPartial1.ResolveGenericArguments(genericBase));
        //
        //     var (type2, arg2, indices2) = intPartial2.ResolveGenericArguments(genericBase);
        //     Assert.AreEqual(2, arg2.Count);
        //     Assert.AreEqual(2, indices2.Count);
        //     Assert.IsTrue(ImportReference<double>().IsTypeEqual(arg2[0]));
        //     Assert.IsTrue(ImportReference<float>().IsTypeEqual(arg2[1]));
        //     Assert.AreEqual(2, indices2[0]);
        //     Assert.AreEqual(0, indices2[1]);
        //
        //     var (type3, arg3, indices3) = intPartial3.ResolveGenericArguments(genericBase);
        //     Assert.AreEqual(3, arg3.Count);
        //     Assert.AreEqual(3, indices3.Count);
        //     Assert.IsTrue(ImportReference<int>().IsTypeEqual(arg3[0]));
        //     Assert.IsTrue(ImportReference<float>().IsTypeEqual(arg3[1]));
        //     Assert.IsTrue(ImportReference<double>().IsTypeEqual(arg3[2]));
        //     Assert.AreEqual(1, indices3[0]);
        //     Assert.AreEqual(0, indices3[1]);
        //     Assert.AreEqual(2, indices3[2]);
        // }
        //
        // [Test]
        // public void should_get_all_types()
        // {
        //     var typeDef = ImportReference<Test.MultipleGenericObject>().Resolve();
        //     var allTypes = typeDef.GetSelfAndAllDeclaringTypes();
        // }
        //
        // [Test]
        // public void should_create_a_new_type_and_create_from_activator()
        // {
        //     var obj = ImportReference(typeof(MultipleGeneric.Object<,>)).Resolve();
        //     var genericType = obj.CreateGenericTypeReference(new[] {_module.TypeSystem.Int32, _module.TypeSystem.Int32});
        // }
    }
}