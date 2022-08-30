using System;
using System.Collections.Generic;
using System.Linq;
using AnyProcessor.CodeGen;
using Mono.Cecil;
using NUnit.Framework;
using Object = System.Object;

namespace AnyProcessor.Tests
{
    public class CecilTestBase
    {
        protected AssemblyDefinition _assemblyDefinition;
        protected ModuleDefinition _module;
        protected virtual IEnumerable<string> _AdditionalLocations => Enumerable.Empty<string>();

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
#if UNITY_2020_1_OR_NEWER
                    , typeof(UnityEngine.Object).Assembly.Location
#endif
                }.Concat(_AdditionalLocations).ToArray()
                )
            });
            _module = _assemblyDefinition.MainModule;
            OnSetUp();
        }

        [TearDown]
        public void TearDown() => OnTearDown();

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
        protected virtual void OnTearDown() {}

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
                LogError($"cannot import reference of {type.AssemblyQualifiedName}: {ex}");
                throw;
            }
        }

        protected void Log(string msg)
        {
#if UNITY_2020_1_OR_NEWER
            UnityEngine.Debug.Log(msg);
#else
            Console.Out.WriteLine(msg);
#endif
        }
        
        protected void LogError(string error)
        {
#if UNITY_2020_1_OR_NEWER
            UnityEngine.Debug.LogError(error);
#else
            Console.Error.WriteLine(error);
#endif
        }
        
        protected TypeDefinition ImportDefinition<T>() => ImportDefinition(typeof(T));
        protected TypeDefinition ImportDefinition(Type type) => ImportReference(type).Resolve();

        protected void AssertTypeEqual(TypeReference lhs, TypeReference rhs)
        {
            Assert.IsTrue(lhs.TypeEquals(rhs));
        }
        
        protected void AssertTypeEqual<T>(TypeReference lhs)
        {
            Assert.IsTrue(lhs.TypeEquals(ImportReference(typeof(T))));
        }
    }
}