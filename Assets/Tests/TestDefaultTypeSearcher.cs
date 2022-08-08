using System.Linq;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace AnySerialize.Tests
{
    public class TestDefaultTypeSearcher : CecilTestBase
    {
        [Test]
        public void should_resolve_unity_type()
        {
            var type = ImportReference<ExitPlayMode>().Resolve();
            Assert.AreEqual(1, type.Interfaces.Count);
            var interfaceReference = type.Interfaces.First();
            Assert.NotNull(interfaceReference);
            Assert.NotNull(interfaceReference.InterfaceType);
            Assert.NotNull(interfaceReference.InterfaceType.Resolve());
        }
    }
}