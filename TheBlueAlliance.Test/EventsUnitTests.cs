using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheBlueAlliance.Models;

namespace TheBlueAlliance.Test
{
    [TestClass]
    public class EventsUnitTests
    {
        [TestMethod]
        public void GetEventInformation_TestMethod()
        {
            Event.EventInformation eventInformation = Events.GetEventInformation("2015onto");
            string actualName = Events.GetEventInformation("2015onto").name;

            string expectedName = "Greater Toronto East Regional";

            Assert.AreEqual(expectedName, actualName, "Event Names Are Not As Expected");
        }

        [TestMethod]
        public void GetEventAwards_TestMethod()
        {
            string actualAwardName = Events.GetEventAwards("2015onto")[0].name;

            string expectedAwardName = "Regional Chairman's Award";

            Assert.AreEqual(expectedAwardName, actualAwardName, "Event Awards Are Not As Expected");
        }
    }
}
