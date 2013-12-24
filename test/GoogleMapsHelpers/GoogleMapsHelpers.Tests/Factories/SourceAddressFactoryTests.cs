using GoogleMapsHelpers.Factories;
using GoogleMapsHelpers.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsHelpers.Tests.Factories
{
    [TestClass]
    public class SourceAddressFactoryTests
    {
        [TestMethod]
        public void SourceAddressFactory_Test()
        {
            var expected = "https://maps.googleapis.com/maps/api/js?key=key123&sensor=true";
            var actual = SourceAddressFactory.GetSourceAddress("key123", true, Libraries.None);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SourceAddressFactory_NoApiKey_Test()
        {
            var expected = "https://maps.googleapis.com/maps/api/js?sensor=true";
            var actual = SourceAddressFactory.GetSourceAddress(null, true, Libraries.None);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SourceAddressFacotry_Library_Test()
        {
            var expected = "https://maps.googleapis.com/maps/api/js?sensor=true&libraries=places";
            var actual = SourceAddressFactory.GetSourceAddress(null, true, Libraries.Places);

            Assert.AreEqual(expected, actual);
        }
    }
}
