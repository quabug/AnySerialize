using System;
using System.Collections.Generic;
using System.Reflection;
using AnyProcessor.CodeGen;
using NUnit.Framework;

namespace AnyProcessor.Tests
{
    public class TestReflection : CecilTestBase
    {
        public class A
        {
            public class AA
            {
                public class AAA {}
            }
        }
        
        public class B<T> : Dictionary<int, T> {}

        [Test]
        public void should_get_reflection_type_from_cecil_type()
        {
            Assert.That(typeof(int), Is.EqualTo(ImportReference(typeof(int)).ToReflectionType()));
            Assert.That(typeof(Dictionary<,>), Is.EqualTo(ImportReference(typeof(Dictionary<,>)).ToReflectionType()));
            Assert.That(typeof(Dictionary<int, long>), Is.EqualTo(ImportReference(typeof(Dictionary<int, long>)).ToReflectionType()));
            Assert.That(typeof(int[]), Is.EqualTo(ImportReference(typeof(int[])).ToReflectionType()));
            Assert.That(typeof(int[][]), Is.EqualTo(ImportReference(typeof(int[][])).ToReflectionType()));
            Assert.That(typeof(A.AA.AAA), Is.EqualTo(ImportReference(typeof(A.AA.AAA)).ToReflectionType()));
            Assert.That(typeof(int).MakeByRefType(), Is.EqualTo(ImportReference(typeof(int).MakeByRefType()).ToReflectionType()));
            Assert.That(typeof(int).MakePointerType(), Is.EqualTo(ImportReference(typeof(int).MakePointerType()).ToReflectionType()));

            // NOTE: convert partial type from cecil to reflection will revert its generic parameter name to its definition parameter name
            //       since there's no way to create generic parameter at runtime unless using `System.Reflection.Emit.GenericTypeParameterBuilder`
            //       and `Emit` library is not compatible with Unity's IL2CPP
            //       so I decide leave it.
            var partialReflectionType = _module.ImportType(typeof(B<>).BaseType).ToReflectionType();
            // Assert.That(typeof(B<>).BaseType, Is.EqualTo(partialReflectionType));
            Assert.That("System.Collections.Generic.Dictionary`2[System.Int32,TValue]", Is.EqualTo(partialReflectionType.ToString()));
        }

        [Test]
        public void should_get_nested_type()
        {
            Assert.AreEqual(typeof(A.AA.AAA), Type.GetType("AnyProcessor.Tests.TestReflection+A+AA+AAA"));
            Assert.AreEqual(typeof(A.AA.AAA), Type.GetType(ImportReference(typeof(A.AA.AAA)).FullName.Replace('/', '+')));
        }
        
        [Test]
        public void should_get_cecil_type_from_reflection_type()
        {
            Assert.That(ImportReference<int>().FullName, Is.EqualTo(_module.ImportType(typeof(int)).FullName));
            Assert.That(ImportReference(typeof(Dictionary<,>)).FullName + "<TKey,TValue>", Is.EqualTo(_module.ImportType(typeof(Dictionary<,>)).FullName));
            Assert.That(ImportReference(typeof(Dictionary<int, long>)).FullName, Is.EqualTo(_module.ImportType(typeof(Dictionary<int, long>)).FullName));
            Assert.That(ImportReference(typeof(Dictionary<int, Dictionary<long, float>>)).FullName, Is.EqualTo(_module.ImportType(typeof(Dictionary<int, Dictionary<long, float>>)).FullName));
            Assert.That(ImportReference(typeof(Dictionary<int, long>[])).FullName, Is.EqualTo(_module.ImportType(typeof(Dictionary<int, long>[])).FullName));
            Assert.That(ImportReference(typeof(int[])).FullName, Is.EqualTo(_module.ImportType(typeof(int[])).FullName));
            Assert.That(ImportReference(typeof(int[][])).FullName, Is.EqualTo(_module.ImportType(typeof(int[][])).FullName));
            Assert.That(ImportReference(typeof(A.AA.AAA)).FullName, Is.EqualTo(_module.ImportType(typeof(A.AA.AAA)).FullName));
            Assert.That("System.Collections.Generic.Dictionary`2<System.Int32,T>", Is.EqualTo(_module.ImportType(typeof(B<>).BaseType).FullName));
        }
    }
}