using System;
using AnySerialize.CodeGen;
using Mono.Cecil;
using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;
using Object = System.Object;

namespace AnySerialize.Tests
{
    public class CecilTestBase
    {
        protected AssemblyDefinition _assemblyDefinition;
        protected ModuleDefinition _module;

        [SetUp]
        public void SetUp()
        {
            var assemblyLocation = GetType().Assembly.Location;
            _assemblyDefinition = AssemblyDefinition.ReadAssembly(assemblyLocation, new ReaderParameters
            {
                AssemblyResolver = new CodeGen.PostProcessorAssemblyResolver(new []
                {
                    GetType().Assembly.Location
                    , typeof(object).Assembly.Location
                    , typeof(Object).Assembly.Location
                    , typeof(AnotherAssembly).Assembly.Location
                })
            });
            _module = _assemblyDefinition.MainModule;
            OnSetUp();
        }

        protected virtual void OnSetUp() {}

        protected TypeReference ImportReference<T>() => ImportReference(typeof(T));
        protected TypeReference ImportReference(Type type)
        {
            try
            {
                return _module.ImportReference(type);
            }
            catch (Exception ex)
            {
                Debug.LogError($"cannot import reference of {type.AssemblyQualifiedName}: {ex}");
                throw;
            }
        }

        protected void AssertTypeEqual(TypeReference lhs, TypeReference rhs)
        {
            Assert.IsTrue(lhs.IsTypeEqual(rhs));
        }
    }
}