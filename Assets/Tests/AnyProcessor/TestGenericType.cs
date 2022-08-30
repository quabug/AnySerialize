using System.Linq;
using AnyProcessor.CodeGen;
using NUnit.Framework;

namespace AnyProcessor.Tests
{
    public class TestGenericType : CecilTestBase
    {
        interface IGeneric<T, U> {}
        class TInt<T> : IGeneric<T, int> {}
        class TComplex<T> : IGeneric<IGeneric<T, int>, int>, IGeneric<float, T>, IGeneric<double, int> {}
        class TIntSub : TInt<int> {}
        
        [Test]
        public void should_check_is_generic_type()
        {
            Assert.IsTrue(_module.ImportReference(typeof(IGeneric<,>)).IsGenericType());
            Assert.IsFalse(_module.ImportReference(typeof(IGeneric<int,float>[])).IsGenericType());
            Assert.IsFalse(_module.ImportReference(typeof(IGeneric<int,float>[][])).IsGenericType());
            Assert.IsFalse(_module.ImportReference(typeof(TIntSub)).IsGenericType());
            Assert.IsFalse(_module.ImportReference(typeof(TIntSub[])).IsGenericType());
            Assert.IsTrue(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[0].InterfaceType.IsGenericType());
            Assert.IsTrue(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[1].InterfaceType.IsGenericType());
            Assert.IsTrue(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[2].InterfaceType.IsGenericType());
        }
        
        [Test]
        public void should_check_is_concrete()
        {
            Assert.IsFalse(_module.ImportReference(typeof(IGeneric<,>)).IsConcreteType());
            Assert.IsFalse(_module.ImportReference(typeof(TInt<>)).Resolve().Interfaces[0].InterfaceType.IsConcreteType());
            Assert.IsTrue(_module.ImportReference(typeof(IGeneric<int, float>)).IsConcreteType());
            Assert.IsTrue(_module.ImportReference(typeof(IGeneric<int, float>[])).IsConcreteType());
            Assert.IsTrue(_module.ImportReference(typeof(IGeneric<int, float>[][])).IsConcreteType());
            Assert.IsTrue(_module.ImportReference(typeof(TIntSub)).IsConcreteType());
            Assert.IsTrue(_module.ImportReference(typeof(IGeneric<IGeneric<int, float>, float>)).IsConcreteType());
            Assert.IsTrue(_module.ImportReference(typeof(IGeneric<IGeneric<int, float>, float>[][])).IsConcreteType());
            Assert.IsFalse(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[0].InterfaceType.IsConcreteType());
            Assert.IsFalse(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[1].InterfaceType.IsConcreteType());
            Assert.IsTrue(_module.ImportReference(typeof(TComplex<>)).Resolve().Interfaces[2].InterfaceType.IsConcreteType());
        }
        
        [Test]
        public void should_check_is_partial()
        {
            var generic = _module.ImportReference(typeof(IGeneric<,>));
            var intPartial = _module.ImportReference(typeof(TInt<>)).Resolve().Interfaces[0].InterfaceType;
            var intIntConcrete = _module.ImportReference(typeof(IGeneric<int, int>));
            Assert.IsTrue(generic.IsPartialGenericTypeOf(generic));
            Assert.IsTrue(intPartial.IsPartialGenericTypeOf(generic));
            Assert.IsTrue(intPartial.IsPartialGenericTypeOf(intPartial));
            Assert.IsFalse(intPartial.IsPartialGenericTypeOf(intIntConcrete));
            Assert.IsTrue(intIntConcrete.IsPartialGenericTypeOf(intPartial));
        }

        [Test]
        public void should_get_implementations()
        {
            var generic = _module.ImportReference(typeof(IGeneric<,>));
            var intPartial = _module.ImportReference(typeof(TInt<>)).Resolve().Interfaces[0].InterfaceType;
            var intIntConcrete = _module.ImportReference(typeof(IGeneric<int, int>));
            var intFloatConcrete = _module.ImportReference(typeof(IGeneric<int, float>));
            var tInt = _module.ImportReference(typeof(TInt<>));
            var tComplex = _module.ImportReference(typeof(TComplex<>));

            var genericImpls = tInt.GetImplementationsOf(generic);
            Assert.That(genericImpls, Is.EquivalentTo(new [] {intPartial}));

            var intPartialImpls = tInt.GetImplementationsOf(intPartial);
            Assert.That(intPartialImpls, Is.EquivalentTo(new [] {intPartial}));
            
            var intIntImpls = tInt.GetImplementationsOf(intIntConcrete);
            Assert.That(intIntImpls, Is.EquivalentTo(new [] {intPartial}));
            
            var intFloatImpls = tInt.GetImplementationsOf(intFloatConcrete);
            Assert.IsFalse(intFloatImpls.Any());

            var complexAll = tComplex.GetImplementationsOf(generic);
            Assert.That(complexAll, Is.EquivalentTo(tComplex.Resolve().Interfaces.Select(i => i.InterfaceType).ToArray()));
            
            var complexIntInt = tComplex.GetImplementationsOf(intIntConcrete);
            Assert.IsFalse(complexIntInt.Any());
            
            var complexIntPartial = tComplex.GetImplementationsOf(intPartial);
            Assert.That(complexIntPartial, Is.EquivalentTo(tComplex.Resolve().Interfaces.Select(i => i.InterfaceType).ToArray()));
            
            var complexGeneric = tComplex.GetImplementationsOf(_module.ImportReference(typeof(IGeneric<IGeneric<int, int>, int>)));
            Assert.That(complexGeneric, Is.EquivalentTo(new[] { tComplex.Resolve().Interfaces[0].InterfaceType }));
        }
    }
}