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
            Event.EventInformation actualEventInformation = Events.GetEventInformation("2015onto");

            string expectedKey = "2015onto";
            string expectedWebsite = "http://www.firstroboticscanada.org";
            bool expectedOfficial = true;
            string expectedEndDate = "2015-03-14";
            string expectedName = "Greater Toronto East Regional";
            string expectedShortName = "Greater Toronto East";
            object expectedFaceBookEID = null;
            object expectedEventDistrictString = null;
            string expectedVenueAddress = "University of Ontario Institute of Technology / Durham College\n2000 Simcoe Street North\nOshawa, ON L1H 7K4\nCanada";
            int expectedEventDistrict = 0;
            string expectedLocation = "Oshawa, ON, Canada";
            string expectedEventCode = "onto";
            int expectedYear = 2015;
            string expectedWebcasts = "livestream";
            string expectedAlliances = "frc2056";
            string expectedEventTypeString = "Regional";
            string expectedStartDate = "2015-03-11";
            int expectedEventType = 0;

            Assert.AreEqual(expectedKey, actualEventInformation.key, "Event Keys Are Not As Expected");
            Assert.AreEqual(expectedWebsite, actualEventInformation.website, "Websites Are Not As Expected");
            Assert.AreEqual(expectedOfficial, actualEventInformation.official, "Is Official Are Not As Expected");
            Assert.AreEqual(expectedEndDate, actualEventInformation.end_date, " Are Not As Expected");
            Assert.AreEqual(expectedName, actualEventInformation.name, "Event Names Are Not As Expected");
            Assert.AreEqual(expectedShortName,actualEventInformation.short_name , "Short Names Are Not As Expected");
            Assert.AreEqual(expectedFaceBookEID, actualEventInformation.facebook_eid, "Facebook EID Are Not As Expected");
            Assert.AreEqual(expectedEventDistrictString, actualEventInformation.event_district_string, "Event District Strings Are Not As Expected");
            Assert.AreEqual(expectedVenueAddress, actualEventInformation.venue_address, "Venue Addresses Are Not As Expected");
            Assert.AreEqual(expectedEventDistrict, actualEventInformation.event_district, "Event Districts Are Not As Expected");
            Assert.AreEqual(expectedLocation, actualEventInformation.location, "Locations Are Not As Expected");
            Assert.AreEqual(expectedEventCode, actualEventInformation.event_code, "Event Codes Are Not As Expected");
            Assert.AreEqual(expectedYear, actualEventInformation.year, "Years Are Not As Expected");
            Assert.AreEqual(expectedWebcasts, actualEventInformation.webcast[0].type, "Webcasts Are Not As Expected");
            Assert.AreEqual(expectedAlliances, actualEventInformation.alliances[0].picks[0], "Alliances Are Not As Expected");
            Assert.AreEqual(expectedEventTypeString, actualEventInformation.event_type_string, "Event Type Strings Are Not As Expected");
            Assert.AreEqual(expectedStartDate, actualEventInformation.start_date, "Start Dates Are Not As Expected");
            Assert.AreEqual(expectedEventType, actualEventInformation.event_type, "Event Types Are Not As Expected");
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
