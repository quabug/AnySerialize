using System.Collections.Generic;
using AnyProccesor.Tests;
using AnyProcessor.CodeGen;
using AnyProcessor.Tests;
using NUnit.Framework;
using UnityEngine;

namespace AnySerialize.Tests
{
    public class TestAnotherAssembly : CecilTestBase
    {
        class AnotherGeneric : AnotherAssembly.Generic {}

        protected override IEnumerable<string> _AdditionalLocations =>
            typeof(AnotherAssembly).Assembly.Location.Yield();

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
    }
}
