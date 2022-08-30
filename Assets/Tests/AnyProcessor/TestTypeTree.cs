using System;
using System.Linq;
using AnyProcessor.CodeGen;
using NUnit.Framework;

namespace AnyProcessor.Tests
{
    public class TestTypeTree : CecilTestBase
    {
        interface IGeneric<T, U> {}
        class TInt<T> : IGeneric<T, int> {}
        class IntU<U> : IGeneric<int, U> {}
        class IntInt : IGeneric<int, int> {}
        class TFloat<T> : IGeneric<T, float> {}
        class AnotherTFloat<T> : IGeneric<T, float> {}
        class TIntSub : TInt<int> {}

        [Test]
        public void should_get_derived_from_generic_interface()
        {
            var tree = LoadTree(typeof(IGeneric<,>));
            CheckDerivedIgnoreGenericParameters(tree, typeof(IGeneric<,>), typeof(TInt<>), typeof(IntU<>), typeof(IntInt), typeof(TFloat<>), typeof(AnotherTFloat<>), typeof(TIntSub));
        }

        [Test]
        public void should_get_derived_from_generic_interface_by_ignoring_generic_parameters()
        {
            var tree = LoadTree(typeof(IGeneric<,>));
            CheckDerivedIgnoreGenericParameters(tree, typeof(IGeneric<int,int>), typeof(TInt<int>), typeof(IntU<int>), typeof(IntInt), typeof(TFloat<int>), typeof(AnotherTFloat<int>), typeof(TIntSub));
        }

        [Test]
        public void should_get_derived_from_concrete_generic_interface()
        {
            var tree = LoadTree(typeof(IGeneric<,>));
            CheckDerived(tree, typeof(IGeneric<int,int>),
                ("TInt<Int32>", "IGeneric<T,Int32>"),
                (nameof(TIntSub), "TInt<Int32>"),
                ("IntU<Int32>", "IGeneric<Int32,U>"),
                (nameof(IntInt), "IGeneric<Int32,Int32>")
            );
        }

        interface I {}
        interface II : I {}
        class A {}
            class AA : A {}
                class AAA : AA, I {}
                    class AAAA : AAA, I {}
                        class AAAAA : AAAA {}
                    class AAAB : AAA {}
                        class AAABA : AAAB {}
                        class AAABB : AAAB {}
                    class AAAC : AAA {}
            class AB : A {}
                class ABA : AB, II {}
                    class ABAA : ABA, I {}
                    class ABAB : ABA {}
                class ABB : AB, I {}
                class ABC : AB {}

        [Test]
        public void should_get_derived_from_class()
        {
            var tree = LoadTree(typeof(A));
            CheckDerived(tree,
                typeof(A),
                    (nameof(AA), nameof(A)),
                        (nameof(AAA), nameof(AA)),
                            (nameof(AAAA), nameof(AAA)),
                                (nameof(AAAAA), nameof(AAAA)),
                            (nameof(AAAB), nameof(AAA)),
                                (nameof(AAABA), nameof(AAAB)),
                                (nameof(AAABB), nameof(AAAB)),
                            (nameof(AAAC), nameof(AAA)),
                    (nameof(AB), nameof(A)),
                        (nameof(ABA), nameof(AB)),
                            (nameof(ABAA), nameof(ABA)),
                            (nameof(ABAB), nameof(ABA)),
                        (nameof(ABB), nameof(AB)),
                        (nameof(ABC), nameof(AB))
            );

            CheckDerived(tree,
                        typeof(AAA),
                            (nameof(AAAA), nameof(AAA)),
                                (nameof(AAAAA), nameof(AAAA)),
                            (nameof(AAAB), nameof(AAA)),
                                (nameof(AAABA), nameof(AAAB)),
                                (nameof(AAABB), nameof(AAAB)),
                            (nameof(AAAC), nameof(AAA))
            );

            CheckDerived(tree,
                    typeof(AB),
                        (nameof(ABA), nameof(AB)),
                            (nameof(ABAA), nameof(ABA)),
                            (nameof(ABAB), nameof(ABA)),
                        (nameof(ABB), nameof(AB)),
                        (nameof(ABC), nameof(AB))
            );
        }

        [Test]
        public void should_get_derived_from_interface()
        {
            var tree = LoadTree(typeof(A));
            CheckDerived(tree,
                typeof(I),
                        (nameof(AAA), nameof(I)),
                            (nameof(AAAA), nameof(AAA)),
                                (nameof(AAAAA), nameof(AAAA)),
                            (nameof(AAAB), nameof(AAA)),
                                (nameof(AAABA), nameof(AAAB)),
                                (nameof(AAABB), nameof(AAAB)),
                            (nameof(AAAC), nameof(AAA)),
                
                            (nameof(AAAA), nameof(I)),
                                (nameof(AAAAA), nameof(AAAA)),
                
                        (nameof(ABA), nameof(I)),
                            (nameof(ABAA), nameof(ABA)),
                            (nameof(ABAB), nameof(ABA)),
                            
                        (nameof(ABAA), nameof(I)),
                        (nameof(ABB), nameof(I))
            );
        }

        void CheckDerived(TypeTree tree, Type @base, params (string type, string impl)[] types)
        {
            var derivedTypes = tree
                .GetOrCreateAllDerivedReferences(_module.ImportReference(@base))
                .Select(t => (t.derivedType.ToReadableName(), t.implementation.ToReadableName()))
            ;
            Assert.That(derivedTypes, Is.EquivalentTo(types));
        }

        void CheckDerivedIgnoreGenericParameters(TypeTree tree, Type @base, params Type[] types)
        {
            var tokens = tree
                .GetAllDerivedDefinition(_module.ImportReference(@base).Resolve())
                .Select(type => type.Name)
            ;
            Assert.That(tokens, Is.EquivalentTo(types.Select(type => _module.ImportReference(type).Resolve().Name)));
        }
    }
}