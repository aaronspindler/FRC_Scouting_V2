using System;
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
            var actualEventInformation = Events.GetEventInformation("2015onto");

            const string expectedKey = "2015onto";
            const string expectedWebsite = "http://www.firstroboticscanada.org";
            const bool expectedOfficial = true;
            const string expectedEndDate = "2015-03-14";
            const string expectedName = "Greater Toronto East Regional";
            const string expectedShortName = "Greater Toronto East";
            const object expectedFaceBookEid = null;
            const object expectedEventDistrictString = null;
            const string expectedVenueAddress = "University of Ontario Institute of Technology / Durham College\n2000 Simcoe Street North\nOshawa, ON L1H 7K4\nCanada";
            const int expectedEventDistrict = 0;
            const string expectedLocation = "Oshawa, ON, Canada";
            const string expectedEventCode = "onto";
            const int expectedYear = 2015;
            const string expectedWebcasts = "livestream";
            const string expectedAlliances = "frc2056";
            const string expectedEventTypeString = "Regional";
            const string expectedStartDate = "2015-03-11";
            const int expectedEventType = 0;

            Assert.AreEqual(expectedKey, actualEventInformation.key, "Event Keys Are Not As Expected");
            Assert.AreEqual(expectedWebsite, actualEventInformation.website, "Websites Are Not As Expected");
            Assert.AreEqual(expectedOfficial, actualEventInformation.official, "Is Official Are Not As Expected");
            Assert.AreEqual(expectedEndDate, actualEventInformation.end_date, " Are Not As Expected");
            Assert.AreEqual(expectedName, actualEventInformation.name, "Event Names Are Not As Expected");
            Assert.AreEqual(expectedShortName, actualEventInformation.short_name, "Short Names Are Not As Expected");
            Assert.AreEqual(expectedFaceBookEid, actualEventInformation.facebook_eid, "Facebook EID Are Not As Expected");
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
            var actualAwardsInformation = Events.GetEventAwards("2015onto");

            string actualEventKey = actualAwardsInformation[0].event_key;
            int actualAwardType = actualAwardsInformation[0].award_type;
            string actualAwardName = actualAwardsInformation[0].name;
            int actualAwardRecipientListTeamNumber = actualAwardsInformation[0].recipient_list[0].team_number;
            object actualAwardRecipientListAwardee = actualAwardsInformation[0].recipient_list[0].awardee;
            int actualYear = actualAwardsInformation[0].year;

            const string expectedEventKey = "2015onto";
            const int expectedAwardType = 0;
            const string expectedAwardName = "Regional Chairman's Award";
            const int expectedAwardRecipientListTeamNumber = 1325;
            const object expectedAwardRecipientListAwardee = null;
            const int expectedYear = 2015;

            Assert.AreEqual(expectedEventKey, actualEventKey, "Event Keys Are Not As Expected");
            Assert.AreEqual(expectedAwardType, actualAwardType, "Award Types Are Not As Expected");
            Assert.AreEqual(expectedAwardName, actualAwardName, "Event Awards Are Not As Expected");
            Assert.AreEqual(expectedAwardRecipientListTeamNumber, actualAwardRecipientListTeamNumber, "Award Team Numbers Are Not As Expected");
            Assert.AreEqual(expectedAwardRecipientListAwardee, actualAwardRecipientListAwardee, "Recipient List Awardee Are Not As Expected");
            Assert.AreEqual(expectedYear, actualYear, "Years Are Not As Expected");
        }

        [TestMethod]
        public void GetEventMatches_TestMethod()
        {
            var actualEventMatches = Events.GetEventMatches("2015onto");

            const string expectedCompLevel = "f";
            const int expectedMatchNumber = 1;
            const string expectedTimeString = null;
            const int expectedSetNumber = 1;
            const string expectedKey = "2015onto_f1m1";
            const int expectedTime = 1426358280;
            const int expectedScoreBreakdownBlueAuto = 0;
            const int expectedAlliancesBlueScore = 155;
            const string expectedAllianceBlueTeam1 = "frc1241";

            Assert.AreEqual(expectedCompLevel, actualEventMatches[0].comp_level, "Comp Levels Are Not As Expected");
            Assert.AreEqual(expectedMatchNumber, actualEventMatches[0].match_number, "Match Numbers Are Not As Expected");
            Assert.AreEqual(expectedTimeString, actualEventMatches[0].time_string, "Time Strings Are Not As Expected");
            Assert.AreEqual(expectedSetNumber, actualEventMatches[0].set_number, "Set Numbers Are Not As Expected");
            Assert.AreEqual(expectedKey, actualEventMatches[0].key, "Keys Are Not As Expected");
            Assert.AreEqual(expectedTime, actualEventMatches[0].time, "Times Are Not As Expected");
            Assert.AreEqual(expectedScoreBreakdownBlueAuto, actualEventMatches[0].score_breakdown.blue.auto, "Score Breakdowns Are Not As Expected");
            Assert.AreEqual(expectedAlliancesBlueScore, actualEventMatches[0].alliances.blue.score, "Scores Are Not As Expected");
            Assert.AreEqual(expectedAllianceBlueTeam1, actualEventMatches[0].alliances.blue.teams[0], "Alliance Teams Are Not As Expected");
        }

        [TestMethod]
        public void GetEventRankings_TestMethod()
        {
            var actualEventRankings = Events.GetEventRankings("2015onto");

            const int expectedRank = 1;
            const int expectedTeam = 2056;
            const double expectedQualAverage = 124.5;
            const int expectedAuto = 146;
            const int expectedContainer = 488;
            const int expectedCoopertition = 160;
            const int expectedLitter = 131;
            const int expectedTote = 338;
            const int expectedPlayed = 10;

            Assert.AreEqual(expectedRank, actualEventRankings[0].Rank, "Ranks Are Not As Expected");
            Assert.AreEqual(expectedTeam, actualEventRankings[0].Team_Number, "Team Numbers Are Not As Expected");
            Assert.AreEqual(expectedQualAverage, actualEventRankings[0].Qual_Average, "Qualification Averages Are Not As Expected");
            Assert.AreEqual(expectedAuto, actualEventRankings[0].Auto, "Auto Points Are Not As Expected");
            Assert.AreEqual(expectedContainer, actualEventRankings[0].Container, "Container Points Are Not As Expected");
            Assert.AreEqual(expectedCoopertition, actualEventRankings[0].Coopertition, "Coopertition Points Are Not As Expected");
            Assert.AreEqual(expectedLitter, actualEventRankings[0].Litter, "Litter Points Are Not As Expected");
            Assert.AreEqual(expectedTote, actualEventRankings[0].Tote, "Tote Points Are Not As Expected");
            Assert.AreEqual(expectedPlayed, actualEventRankings[0].Played, "Matches Played Are Not As Expected");
        }

        [TestMethod]
        public void GetEvents_TestMethod()
        {
            var actualEvents = Events.GetEvents(2015);

            const string expectedKey = "2015abca";
            const string expectedWebsite = "http://frcwest.com/";
            const bool expectedOfficial = true;
            const string expectedEndDate = "2015-04-04";
            const string expectedName = "Western Canada Regional";
            const string expectedShortName = "Western Canada";
            const object expectedFaceBookEid = null;
            const object expectedEventDistrictString = null;
            const string expectedVenueAddress = "Ernest Manning High School\n20 Springborough Blvd SW\nCalgary, AB T3H 0N7\nCanada";
            const int expectedEventDistrict = 0;
            const string expectedLocation = "Calgary, AB, Canada";
            const string expectedEventCode = "abca";
            const int expectedYear = 2015;
            const string expectedAlliances0Pick1 = "frc4719";
            const string expectedEventTypeString = "Regional";
            const string expectedStartDate = "2015-04-01";
            const int expectedEventType = 0;

            Assert.AreEqual(expectedKey, actualEvents[0].key, "Event Keys Are Not As Expected");
            Assert.AreEqual(expectedWebsite, actualEvents[0].website, "Websites Are Not As Expected");
            Assert.AreEqual(expectedOfficial, actualEvents[0].official, "Is Official Are Not As Expected");
            Assert.AreEqual(expectedEndDate, actualEvents[0].end_date, "End Dates Are Not As Expected");
            Assert.AreEqual(expectedName, actualEvents[0].name, "Names Are Not As Expected");
            Assert.AreEqual(expectedShortName, actualEvents[0].short_name, "Short Name Are Not As Expected");
            Assert.AreEqual(expectedFaceBookEid, actualEvents[0].facebook_eid, "Facebook EIDs Are Not As Expected");
            Assert.AreEqual(expectedEventDistrictString, actualEvents[0].event_district_string, "District Strings Are Not As Expected");
            Assert.AreEqual(expectedVenueAddress, actualEvents[0].venue_address, "Venue Addresses Are Not As Expected");
            Assert.AreEqual(expectedEventDistrict, actualEvents[0].event_district, "Event Districts Are Not As Expected");
            Assert.AreEqual(expectedLocation, actualEvents[0].location, "Locations Are Not As Expected");
            Assert.AreEqual(expectedEventCode, actualEvents[0].event_code, "Event Codes Are Not As Expected");
            Assert.AreEqual(expectedYear, actualEvents[0].year, "Years Are Not As Expected");
            Assert.AreEqual(expectedAlliances0Pick1, actualEvents[0].alliances[0].picks[0], "Alliance Picks Are Not As Expected");
            Assert.AreEqual(expectedEventTypeString, actualEvents[0].event_type_string, "Event Type Strings Are Not As Expected");
            Assert.AreEqual(expectedStartDate, actualEvents[0].start_date, "Start Dates Are Not As Expected");
            Assert.AreEqual(expectedEventType, actualEvents[0].event_type, "Event Types Are Not As Expected");
        }

        [TestMethod]
        public void GetEventTeamsList_TestMethod()
        {
            var actualTeamList = Events.GetEventTeamsList("2015onto");
        }
    }
}