﻿using System;
using System.Linq;
using AnySerialize.CodeGen;
using Mono.Cecil;
using NUnit.Framework;
using UnityEditor;

namespace AnySerialize.Tests
{
    public class TestDefaultTypeSearcher : CecilTestBase
    {
        private DefaultTypeSearcher _searcher;
        private TypeTree _typeTree;
        
        protected override void OnSetUp()
        {
            var serializerTypes = TypeCache.GetTypesDerivedFrom<IAny>();
            _typeTree = new TypeTree(serializerTypes.Select(type => _module.ImportReference(type).Resolve()));
            _searcher = new DefaultTypeSearcher();
        }

        [Test]
        public void should_match_primitive_type_to_any_value()
        {
            Assert.That(_searcher.Search(_typeTree, CreateProperty<int>()), Is.EqualTo(new TypeDef(_module.ImportReference(typeof(AnyValue<int>)))));
            Assert.That(_searcher.Search(_typeTree, CreateProperty<float>()), Is.EqualTo(new TypeDef(_module.ImportReference(typeof(AnyValue<float>)))));
            Assert.That(_searcher.Search(_typeTree, CreateProperty<long>()), Is.EqualTo(new TypeDef(_module.ImportReference(typeof(AnyValue<long>)))));
        }

        private PropertyDefinition CreateProperty<T>(Type searchingBaseType = null, string propertyName = "test")
        {
            var propertyType = _module.ImportReference(typeof(T));
            var property = new PropertyDefinition(propertyName, PropertyAttributes.None, propertyType);
            property.DeclaringType = propertyType.Resolve();
            var attribute = property.AddCustomAttribute<AnySerializeAttribute>(_module, typeof(Type));
            attribute.ConstructorArguments.Add(new CustomAttributeArgument(_module.ImportReference(typeof(Type)), searchingBaseType));
            return property;
        }
    }
}