using System.Collections.Generic;
using System.Linq;
using AnyProcessor.CodeGen;
using AnyProcessor.Tests;
using AnySerialize.CodeGen;
using Mono.Cecil;
using NUnit.Framework;

namespace AnySerialize.Tests
{
    public class TestFieldTypeSearcher : CecilTestBase
    {
        private ILPostProcessorLogger _logger;
        
        [SetUp]
        public void SetUp()
        {
            _logger = new ILPostProcessorLogger();
        }

        FieldTypeSearcher CreateSearcher(string fieldDeclaringTypeParameterName, string parameterName, GenericInstanceType genericType)
        {
            return new FieldTypeSearcher(_logger, fieldDeclaringTypeParameterName, genericType, new GenericParameter(parameterName, genericType.Resolve()));
        }
        
        [Test]
        public void should_get_fields_type_from_key_value_pair()
        {
            var type = _module.ImportReference(typeof(ReadOnlyAnyClass<,,,,>)).Resolve();
            var genericType = new GenericInstanceType(type);
            genericType.GenericArguments.Clear();
            genericType.GenericArguments.Add(_module.ImportReference(typeof(KeyValuePair<int, long>)));
            genericType.GenericArguments.Add(type.GenericParameters[1]);
            genericType.GenericArguments.Add(type.GenericParameters[2]);
            genericType.GenericArguments.Add(type.GenericParameters[3]);
            genericType.GenericArguments.Add(type.GenericParameters[4]);
            
            {
                var searcher = CreateSearcher("T", "T0", genericType);
                var fieldType = searcher.Search();
                Assert.That(fieldType.FullName, Is.EqualTo(typeof(int).FullName));
            }
            
            {
                var searcher = CreateSearcher("T", "T1", genericType);
                var fieldType = searcher.Search();
                Assert.That(fieldType.FullName, Is.EqualTo(typeof(long).FullName));
            }
        }
        
        [Test]
        public void should_get_fields_from_type()
        {
            var type = _module.ImportReference(typeof(KeyValuePair<int, long>));
            var fields = type.Resolve().Fields.Where(field => !field.IsStatic).Select(field => field.FieldType).ToArray();
            if (type is GenericInstanceType genericDeclaringType)
            {
                for (var i = 0; i < fields.Length; i++)
                {
                    if (!fields[i].IsConcreteType()) fields[i] = fields[i].FillGenericTypesByReferenceGenericName(genericDeclaringType);
                }
            }
            Assert.That(fields.Select(t => t.FullName), Is.EquivalentTo(new [] { _module.ImportReference(typeof(int)).FullName, _module.ImportReference(typeof(long)).FullName }));
        }
    }
}