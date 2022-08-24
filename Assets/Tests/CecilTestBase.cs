using System;
using System.Linq;
using AnyProccesor.Tests;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;
using Object = System.Object;

namespace AnyProcessor.Tests
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
                AssemblyResolver = new CodeGen.PostProcessorAssemblyResolver(
                    GetType().Assembly.Location
                    , typeof(object).Assembly.Location
                    , typeof(Object).Assembly.Location
                    , typeof(UnityEngine.Object).Assembly.Location
                    , typeof(AnotherAssembly).Assembly.Location
                )
            });
            _module = _assemblyDefinition.MainModule;
            OnSetUp();
        }

        protected TypeTree LoadTree(params Type[] roots)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(type => roots.Any(root => root.IsGenericType
                    ? IsImplementationOfGenericBase(type, root)
                    : root.IsAssignableFrom(type))
                )
                .Select(ImportDefinition)
            ;
            return new TypeTree(types);

            bool IsImplementationOfGenericBase(Type self, Type genericBase)
            {
                var genericBaseDef = genericBase.GetGenericTypeDefinition();
                if (genericBase.IsInterface) return self.GetInterfaces().Any(@interface => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == genericBaseDef);
                while (self != null)
                {
                    if (self.GetGenericTypeDefinition() == genericBaseDef) return true;
                    self = self.BaseType;
                }
                return false;
            }
        }

        protected virtual void OnSetUp() {}

        protected TypeReference ImportReference<T>(T _) => ImportReference(typeof(T));
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
        
        protected TypeDefinition ImportDefinition<T>() => ImportDefinition(typeof(T));
        protected TypeDefinition ImportDefinition(Type type) => ImportReference(type).Resolve();

        protected void AssertTypeEqual(TypeReference lhs, TypeReference rhs)
        {
            Assert.IsTrue(lhs.TypeEquals(rhs));
        }
    }
}