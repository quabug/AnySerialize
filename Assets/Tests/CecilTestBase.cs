using System;
using Mono.Cecil;
using NUnit.Framework;

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
                AssemblyResolver = new AnySerialize.CodeGen.PostProcessorAssemblyResolver(new []
                {
                    GetType().Assembly.Location
                    , typeof(object).Assembly.Location
                    , typeof(AnotherAssembly).Assembly.Location
                })
            });
            _module = _assemblyDefinition.MainModule;
            OnSetUp();
        }

        protected virtual void OnSetUp() {}

        protected TypeReference ImportReference<T>() => ImportReference(typeof(T));
        protected TypeReference ImportReference(Type type) => _assemblyDefinition.MainModule.ImportReference(type);
    }
}