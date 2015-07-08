using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheBlueAlliance.Test
{
    [TestClass]
    public class MatchesUnitTests
    {
        [TestMethod]
        public void GetMatchInformation_TestMethod()
        {
            var actualMatchInformation = Matches.GetMatchInformation("2015onnb_f1m3");

            var expectedCompLevel = "f";
            var expectedMatchNumber = 3;
            string expectedTimeString = null;
            var expectedSetNumber = 1;
            var expectedKey = "2015onnb_f1m3";
            var expectedTime = 1427569680;
            var expectedScoreBreakdownBlueAuto = 0;
            var expectedScoreBreakdownBlueFoul = 0;
            var expectedScoreBreakdownRedAuto = 20;
            var expectedScoreBreakdownRedFoul = 0;
            var expectedAlliancesBlueScore = 100;
            var expectedAlliancesBlueTeam0 = "frc4917";
            var expectedAlliancesBlueTeam1 = "frc4001";
            var expectedAlliancesBlueTeam2 = "frc3710";
            var expectedAllianceRedScore = 167;
            var expectedAllianceRedTeam0 = "frc1310";
            var expectedAllianceRedTeam1 = "frc4678";
            var expectedAllianceRedTeam2 = "frc2013";
            var expectedEventKey = "2015onnb";

            Assert.AreEqual(expectedCompLevel, actualMatchInformation.comp_level, "Comp levels are not as expected");
            Assert.AreEqual(expectedMatchNumber, actualMatchInformation.match_number,"Match numbers are not as expected");
            Assert.AreEqual(expectedTimeString, actualMatchInformation.time_string, "Time strings are not as expected");
            Assert.AreEqual(expectedSetNumber, actualMatchInformation.set_number, "Set numbers are not as expected");
            Assert.AreEqual(expectedKey, actualMatchInformation.key, "Keys are not as expected");
            Assert.AreEqual(expectedTime, actualMatchInformation.time, "Times are not as expected");
            Assert.AreEqual(expectedScoreBreakdownBlueAuto, actualMatchInformation.score_breakdown.blue.auto, "Blue alliance auto scores are not as expected");
            Assert.AreEqual(expectedScoreBreakdownBlueFoul, actualMatchInformation.score_breakdown.blue.foul, "Blue alliance foul scores are not as expected");
            Assert.AreEqual(expectedScoreBreakdownRedAuto, actualMatchInformation.score_breakdown.red.auto, "Red alliance auto scores are not as expected");
            Assert.AreEqual(expectedScoreBreakdownRedFoul, actualMatchInformation.score_breakdown.red.foul, "Red alliance foul scores are not as expected");
            Assert.AreEqual(expectedAlliancesBlueScore, actualMatchInformation.alliances.blue.score, "Blue alliance overall scores are not as expected");
            Assert.AreEqual(expectedAlliancesBlueTeam0, actualMatchInformation.alliances.blue.teams[0], "Blue alliance teams are not as expected");
            Assert.AreEqual(expectedAlliancesBlueTeam1, actualMatchInformation.alliances.blue.teams[1], "Blue alliance teams are not as expected");
            Assert.AreEqual(expectedAlliancesBlueTeam2, actualMatchInformation.alliances.blue.teams[2], "Blue alliance teams are not as expected");
            Assert.AreEqual(expectedAllianceRedScore, actualMatchInformation.alliances.red.score, "Red alliance overall scores are not as expected");
            Assert.AreEqual(expectedAllianceRedTeam0, actualMatchInformation.alliances.red.teams[0], "Red alliance teams are not as expected");
            Assert.AreEqual(expectedAllianceRedTeam1, actualMatchInformation.alliances.red.teams[1], "Red alliance teams are not as expected");
            Assert.AreEqual(expectedAllianceRedTeam2, actualMatchInformation.alliances.red.teams[2], "Red alliance teams are not as expected");
            Assert.AreEqual(expectedEventKey, actualMatchInformation.event_key, "Event keys are not as expected");


        }
    }
}
