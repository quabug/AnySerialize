using AnyProcessor.CodeGen;
using Mono.Cecil;
using NUnit.Framework;

namespace AnyProcessor.Tests
{
    public class TestTypeEqual : CecilTestBase
    {
        [Test]
        public void should_equal_with_same_type()
        {
            var intType = ImportReference<int>();
            var floatType = ImportReference<float>();
            var longType = ImportReference<long>();
            Assert.IsTrue(intType.TypeEquals(intType));
            Assert.IsTrue(floatType.TypeEquals(floatType));
            Assert.IsTrue(longType.TypeEquals(longType));
            Assert.IsTrue(intType.TypeEquals(intType.Resolve()));
            Assert.IsTrue(intType.Resolve().TypeEquals(intType.Resolve()));
            Assert.IsTrue(intType.Resolve().TypeEquals(intType));
        }
        
        [Test]
        public void should_not_equal_with_different_type()
        {
            var intType = ImportReference<int>();
            var floatType = ImportReference<float>();
            var longType = ImportReference<long>();
            Assert.IsFalse(intType.TypeEquals(floatType));
            Assert.IsFalse(intType.Resolve().TypeEquals(floatType.Resolve()));
            Assert.IsFalse(longType.Resolve().TypeEquals(floatType));
            Assert.IsFalse(longType.TypeEquals(floatType));
        }
        
        interface IGenericParameters<T0, T1, T2, in T3, out T4, T5>
            where T1 : class
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {}
        
        [Test]
        public void should_check_equatable_of_generic_parameters()
        {
            var parameters = ImportReference(typeof(IGenericParameters<,,,,,>)).Resolve().GenericParameters;
            var t0 = parameters[0];
            var t1 = parameters[1];
            var t2 = parameters[2];
            var t3 = parameters[3];
            var t4 = parameters[4];
            var t5 = parameters[5];
            
            Assert.IsFalse(ImportReference<int>().TypeEquals(t0));
            Assert.IsFalse(t0.TypeEquals(ImportReference<int>()));
            Assert.IsTrue(t0.TypeEquals(t1));
            Assert.IsFalse(t1.TypeEquals(t2));
            Assert.IsFalse(t2.TypeEquals(t3));
            Assert.IsFalse(t3.TypeEquals(t4));
            Assert.IsFalse(t4.TypeEquals(t5));
            Assert.IsTrue(t2.TypeEquals(t5));
            
            Assert.IsTrue(((TypeReference)t0).TypeEquals(t1));
            Assert.IsFalse(((TypeReference)t1).TypeEquals(t2));
            Assert.IsFalse(((TypeReference)t2).TypeEquals(t3));
            Assert.IsFalse(((TypeReference)t3).TypeEquals(t4));
            Assert.IsFalse(((TypeReference)t4).TypeEquals(t5));
            Assert.IsTrue(((TypeReference)t2).TypeEquals(t5));
        }
        
        interface IGeneric<T0, T1, T2> {}
        class G0<T> : IGeneric<int, T, T> {}
        class G1<T0, T1> : IGeneric<int, T0, T1> {}
        class G2<T> : IGeneric<int, T, T> where T : struct {}
        class G3<T> : IGeneric<T, T, T> {}
        class G4 : IGeneric<int, int, int> {}

        [Test]
        public void should_check_equatable_of_generic_types()
        {
            var g = ImportReference(typeof(IGeneric<,,>));
            var g0 = ImportReference(typeof(G0<>)).Resolve().Interfaces[0].InterfaceType;
            var g1 = ImportReference(typeof(G1<,>)).Resolve().Interfaces[0].InterfaceType;
            var g2 = ImportReference(typeof(G2<>)).Resolve().Interfaces[0].InterfaceType;
            var g3 = ImportReference(typeof(G3<>)).Resolve().Interfaces[0].InterfaceType;
            var g4 = ImportReference(typeof(G4)).Resolve().Interfaces[0].InterfaceType;
            Assert.IsFalse(g.TypeEquals(ImportReference<int>()));
            Assert.IsFalse(g.TypeEquals(g0));
            Assert.IsTrue(g.TypeEquals(g3));
            Assert.IsTrue(g0.TypeEquals(g1));
            Assert.IsFalse(g0.TypeEquals(g2));
            Assert.IsFalse(g0.TypeEquals(g3));
            Assert.IsFalse(g0.TypeEquals(g4));
            
            Assert.IsTrue(((GenericInstanceType)g0).TypeEquals((GenericInstanceType)g1));
            Assert.IsFalse(((GenericInstanceType)g0).TypeEquals((GenericInstanceType)g2));
            Assert.IsFalse(((GenericInstanceType)g0).TypeEquals((GenericInstanceType)g3));
            Assert.IsFalse(((GenericInstanceType)g0).TypeEquals((GenericInstanceType)g4));
        }
        
        [Test]
        public void should_equal_with_same_generic_type()
        {
            var refDef = _module.ImportReference(typeof(IGeneric<,,>));
            var defDef = _module.ImportReference(typeof(IGeneric<,,>)).Resolve();
            Assert.IsTrue(refDef.TypeEquals(defDef));
        }
        
        [Test]
        public void should_not_equal_with_different_generic_type()
        {
            var def = _module.ImportReference(typeof(IGeneric<,,>));
            var partialDef = _module.ImportReference(typeof(G0<>)).Resolve().Interfaces[0].InterfaceType;
            Assert.IsFalse(def.TypeEquals(partialDef));
        }

        private IGeneric<int, int, float>[] _array0;
        private IGeneric<int, int, float>[] _array1;
        private IGeneric<int, float, float>[] _array2;
        private G4[] _array3;
        private G4[] _array4;

        [Test]
        public void should_check_equatable_of_array_types()
        {
            var array0 = ImportReference(_array0);
            var array1 = ImportReference(_array1);
            var array2 = ImportReference(_array2);
            var array3 = ImportReference(_array3);
            var array4 = ImportReference(_array4);
            
            Assert.IsTrue(array0.TypeEquals(array1));
            Assert.IsFalse(array1.TypeEquals(array2));
            Assert.IsFalse(array2.TypeEquals(array3));
            Assert.IsTrue(array3.TypeEquals(array4));
            Assert.IsFalse(array4.TypeEquals(array0));
        }
    }
}