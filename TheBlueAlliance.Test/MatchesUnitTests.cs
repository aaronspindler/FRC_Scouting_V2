using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheBlueAlliance.Models;

namespace TheBlueAlliance.Test
{
    [TestClass]
    public class MatchesUnitTests
    {
        [TestMethod]
        public void GetMatchInformation_TestMethod()
        {
            MatchInformation.Match actualMatchInformation = Matches.GetMatchInformation("2015onnb_f1m3");

            string expectedCompLevel = "qm";
            int expectedMatchNumber = 43;
            string expectedTimeString = null;
            int expectedSetNumber = 1;
            string expectedKey = "2015iri_qm43";
            int expectedTime = 1437161040;

            Assert.AreEqual(expectedCompLevel, actualMatchInformation.comp_level, "Comp Levels are not as expected!");
            Assert.AreEqual(expectedMatchNumber, actualMatchInformation.match_number, "Match Numbers are not as expected!");
            Assert.AreEqual(expectedTimeString, actualMatchInformation.time_string, "Time strings are not as expected!");
            Assert.AreEqual(expectedSetNumber, actualMatchInformation.set_number, "Set numbers are not as expected!");
            Assert.AreEqual(expectedKey, actualMatchInformation.key, "Keys are not as expected!");
            Assert.AreEqual(expectedTime, actualMatchInformation.time, "Times are not as expected!");

            int expectedScoreBreakdownBlue_Tote_Count_Far = 24;
            int expectedScoreBreakdownBlue_Tote_Count_Near = 14;
            int expectedScoreBreakdownBlue_container_count_level1 = 0;
            int expectedScoreBreakdownBlue_container_count_level2 = 0;
            int expectedScoreBreakdownBlue_container_count_level3 = 0;
            int expectedScoreBreakdownBlue_container_count_level4 = 0;
            int expectedScoreBreakdownBlue_container_count_level5 = 0;
            int expectedScoreBreakdownBlue_container_count_level6 = 5;
            int expectedScoreBreakdownBlue_teleop_points = 226;
            int expectedScoreBreakdownBlue_auto_points = 20;
            int expectedScoreBreakdownBlue_total_points = 280;
            Boolean expectedScoreBreakdownBlue_tote_set = false;
            Boolean expectedScoreBreakdownBlue_container_set = false;
            int expectedScoreBreakdownBlue_foul_count = 1;
            int expectedScoreBreakdownBlue_container_pointers = 120;
            int expectedScoreBreakdownBlue_adjust_points = 0;
            int expectedScoreBreakdownBlue_litter_count_unprocessed = 0;
            Boolean expectedScoreBreakdownBlue_robot_set = false;
            int expectedScoreBreakdownBlue_litter_count_container = 5;
            int expectedScoreBreakdownBlue_tote_points = 76;
            int expectedScoreBreakdownBlue_foul_points = 6;
            Boolean expectedScoreBreakdownBlue_tote_stack = true;
            int expectedScoreBreakdownBlue_litter_count_landfill = 0;
            int expectedScoreBreakdownBlue_litter_points = 30;

            Assert.AreEqual(expectedScoreBreakdownBlue_Tote_Count_Far,actualMatchInformation.score_breakdown.blue.tote_count_far, "Tote count far is not as expected!");
            Assert.AreEqual(expectedScoreBreakdownBlue_Tote_Count_Near,actualMatchInformation.score_breakdown.blue.tote_count_near,"Tote count near is not as expected!");
            Assert.AreEqual(expectedScoreBreakdownBlue_container_count_level1,actualMatchInformation.score_breakdown.blue.container_count_level1,"Container count level 1 is not as expected!");
            Assert.AreEqual(expectedScoreBreakdownBlue_container_count_level2,actualMatchInformation.score_breakdown.blue.container_count_level2,"Container count level 2 is not as expected!");
            Assert.AreEqual(expectedScoreBreakdownBlue_container_count_level3,actualMatchInformation.score_breakdown.blue.container_count_level3,"Container count level 3 is not as expected!");
            Assert.AreEqual(expectedScoreBreakdownBlue_container_count_level4,actualMatchInformation.score_breakdown.blue.container_count_level4,"Container count level 4 is not as expected!");
            Assert.AreEqual(expectedScoreBreakdownBlue_container_count_level5,actualMatchInformation.score_breakdown.blue.container_count_level5,"Container count level 5 is not as expected!");
            Assert.AreEqual(expectedScoreBreakdownBlue_container_count_level6,actualMatchInformation.score_breakdown.blue.container_count_level6,"Container count level 6 is not as expected!");
            Assert.AreEqual(expectedScoreBreakdownBlue_teleop_points,actualMatchInformation.score_breakdown.blue.teleop_points,"Teleop points is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");
            Assert.AreEqual(,actualMatchInformation.score_breakdown.blue.," is not as expected!");






            string expectedCoopertition = "Stack";

            int expectedScoreBreakdownRed_Tote_Count_Far = 18;
            int expectedScoreBreakdownRed_Tote_Count_Near = 22;
            int expectedScoreBreakdownRed_container_count_level1 = 0;
            int expectedScoreBreakdownRed_container_count_level2 = 0;
            int expectedScoreBreakdownRed_container_count_level3 = 0;
            int expectedScoreBreakdownRed_container_count_level4 = 0;
            int expectedScoreBreakdownRed_container_count_level5 = 0;
            int expectedScoreBreakdownRed_container_count_level6 = 5;
            int expectedScoreBreakdownRed_teleop_points = 218;
            int expectedScoreBreakdownRed_auto_points = 28;
            int expectedScoreBreakdownRed_total_points = 286;
            Boolean expectedScoreBreakdownRed_tote_set = false;
            Boolean expectedScoreBreakdownRed_container_set = true;
            int expectedScoreBreakdownRed_foul_count = 0;
            int expectedScoreBreakdownRed_container_pointers = 120;
            int expectedScoreBreakdownRed_adjust_points = 0;
            int expectedScoreBreakdownRed_litter_count_unprocessed = 0;
            Boolean expectedScoreBreakdownRed_robot_set = false;
            int expectedScoreBreakdownRed_litter_count_container = 3;
            int expectedScoreBreakdownRed_tote_points = 80;
            int expectedScoreBreakdownRed_foul_points = 0;
            Boolean expectedScoreBreakdownRed_tote_stack = true;
            int expectedScoreBreakdownRed_litter_count_landfill = 0;
            int expectedScoreBreakdownRed_litter_points = 18;

            int expected_coopertition_points = 40;

            int expectedAlliancesBlueScore = 280;
            string expectedAlliancesBlue0 = "frc624";
            string expectedAlliancesBlue1 = "frc1619";
            string expectedAlliancesBlue2 = "frc4678";

            int expectedAlliancesRedScore = 286;
            string expectedAlliancesRed0 = "frc4143";
            string expectedAlliancesRed1 = "frc2826";
            string expectedAlliancesRed2 = "frc5413";

            string expectedEventKey = "2015iri";

        }
    }
}