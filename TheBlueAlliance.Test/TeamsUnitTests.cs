using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheBlueAlliance.Test
{
    [TestClass]
    public class TeamsUnitTests
    {
        [TestMethod]
        public void GetTeamEventAwardsTest()
        {
            var actualInformation = Teams.GetTeamEventAwards("frc3710", "2015onto");

            string expectedEventKey = "2015onto";
            int expectedAwardType = 1;
            string expectedName = "Regional Winners";
            int expectedRecipientNumber0 = 2056;
            int expectedRecipientNumber1 = 2852;
            int expectedRecipientNumber2 = 3710;
            int expectedYear = 2015;

            Assert.AreEqual(expectedEventKey, actualInformation[0].event_key);
            Assert.AreEqual(expectedAwardType, actualInformation[0].award_type);
            Assert.AreEqual(expectedName, actualInformation[0].name);
            Assert.AreEqual(expectedRecipientNumber0, actualInformation[0].recipient_list[0].team_number);
            Assert.AreEqual(expectedRecipientNumber1, actualInformation[0].recipient_list[1].team_number);
            Assert.AreEqual(expectedRecipientNumber2, actualInformation[0].recipient_list[2].team_number);
            Assert.AreEqual(expectedYear, actualInformation[0].year);
        }
    }
}
