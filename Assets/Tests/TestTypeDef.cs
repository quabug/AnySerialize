using System.Linq;
using AnySerialize.CodeGen;
using NUnit.Framework;

namespace AnySerialize.Tests
{
    public class TestTypeDef : CecilTestBase
    {
        interface IGeneric<T, U> {}
        class TInt<T> : IGeneric<T, int> {}
        class TComplex<T> : IGeneric<IGeneric<T, int>, int>, IGeneric<float, T>, IGeneric<double, int> {}
        class TIntSub : TInt<int> {}
        
        [Test]
        public void should_check_is_generic_type()
        {
            Assert.IsTrue(new TypeDef(_module.ImportReference(typeof(IGeneric<,>))).IsGenericType);
            Assert.IsFalse(new TypeDef(_module.ImportReference(typeof(TIntSub))).IsGenericType);
        }
        
        [Test]
        public void should_check_is_concrete()
        {
            Assert.IsFalse(new TypeDef(_module.ImportReference(typeof(IGeneric<,>))).IsConcreteType);
            Assert.IsFalse(new TypeDef(_module.ImportReference(typeof(TInt<>)).Resolve().Interfaces[0]).IsConcreteType);
            Assert.IsTrue(new TypeDef(_module.ImportReference(typeof(IGeneric<int, float>))).IsConcreteType);
            Assert.IsTrue(new TypeDef(_module.ImportReference(typeof(TIntSub))).IsConcreteType);
            Assert.IsTrue(new TypeDef(_module.ImportReference(typeof(IGeneric<IGeneric<int, float>, float>))).IsConcreteType);
            Assert.IsFalse(new TypeDef(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[0]).IsConcreteType);
            Assert.IsFalse(new TypeDef(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[1]).IsConcreteType);
            Assert.IsTrue(new TypeDef(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[2]).IsConcreteType);
        }
        
        [Test]
        public void should_check_is_partial()
        {
            var generic = new TypeDef(_module.ImportReference(typeof(IGeneric<,>)));
            var intPartial = new TypeDef(_module.ImportReference(typeof(TInt<>)).Resolve().Interfaces[0]);
            var intIntConcrete = new TypeDef(_module.ImportReference(typeof(IGeneric<int, int>)));
            Assert.IsTrue(generic.IsPartialGenericTypeOf(generic));
            Assert.IsTrue(intPartial.IsPartialGenericTypeOf(generic));
            Assert.IsTrue(intPartial.IsPartialGenericTypeOf(intPartial));
            Assert.IsFalse(intPartial.IsPartialGenericTypeOf(intIntConcrete));
            Assert.IsTrue(intIntConcrete.IsPartialGenericTypeOf(intPartial));
        }

        [Test]
        public void should_equal_with_same_generic_type()
        {
            var refDef = new TypeDef(_module.ImportReference(typeof(IGeneric<,>)));
            var defDef = new TypeDef(_module.ImportReference(typeof(IGeneric<,>)).Resolve());
            Assert.AreEqual(refDef, defDef);
        }
        
        [Test]
        public void should_not_equal_with_different_generic_type()
        {
            var def = new TypeDef(_module.ImportReference(typeof(IGeneric<,>)));
            var partialDef = new TypeDef(_module.ImportReference(typeof(TInt<>)).Resolve().Interfaces[0]);
            Assert.AreNotEqual(def, partialDef);
        }
        
        [Test]
        public void should_get_implementations()
        {
            var generic = new TypeDef(_module.ImportReference(typeof(IGeneric<,>)));
            var intPartial = new TypeDef(_module.ImportReference(typeof(TInt<>)).Resolve().Interfaces[0]);
            var intIntConcrete = new TypeDef(_module.ImportReference(typeof(IGeneric<int, int>)));
            var intFloatConcrete = new TypeDef(_module.ImportReference(typeof(IGeneric<int, float>)));
            var tInt = new TypeDef(_module.ImportReference(typeof(TInt<>)));
            var tComplex = new TypeDef(_module.ImportReference(typeof(TComplex<>)));

            var genericImpls = tInt.GetImplementationsOf(generic);
            Assert.That(genericImpls, Is.EquivalentTo(new [] {intPartial}));

            var intPartialImpls = tInt.GetImplementationsOf(intPartial);
            Assert.That(intPartialImpls, Is.EquivalentTo(new [] {intPartial}));
            
            var intIntImpls = tInt.GetImplementationsOf(intIntConcrete);
            Assert.That(intIntImpls, Is.EquivalentTo(new [] {intPartial}));
            
            var intFloatImpls = tInt.GetImplementationsOf(intFloatConcrete);
            Assert.IsFalse(intFloatImpls.Any());

            var complexAll = tComplex.GetImplementationsOf(generic);
            Assert.That(complexAll, Is.EquivalentTo(tComplex.Type.Interfaces.Select(i => new TypeDef(i)).ToArray()));
            
            var complexIntInt = tComplex.GetImplementationsOf(intIntConcrete);
            Assert.IsFalse(complexIntInt.Any());
            
            var complexIntPartial = tComplex.GetImplementationsOf(intPartial);
            Assert.That(complexIntPartial, Is.EquivalentTo(tComplex.Type.Interfaces.Select(i => new TypeDef(i)).ToArray()));
            
            var complexGeneric = tComplex.GetImplementationsOf(_module.ImportReference(typeof(IGeneric<IGeneric<int, int>, int>)));
            Assert.That(complexGeneric, Is.EquivalentTo(new TypeDef[] { tComplex.Type.Interfaces[0] }));
        }
    }
}