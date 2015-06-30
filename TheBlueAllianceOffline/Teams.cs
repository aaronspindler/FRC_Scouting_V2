using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TheBlueAllianceOffline.Models;

namespace TheBlueAllianceOffline
{
    public class Teams
    {
        public static TeamEventAwards.Award[] GetTeamEventAwards(string teamKey, string eventKey)
        {
            var teamEventAwardsToReturn = new List<TeamEventAwards.Award>();
            string teamNum = teamKey.Substring(4);
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "AwardsAt" + eventKey + ".html");
            string fileLines = File.ReadAllText(path);
            teamEventAwardsToReturn =
                    JsonConvert.DeserializeObject<List<TeamEventAwards.Award>>(path);
            return teamEventAwardsToReturn.ToArray();
        }

        public static TeamEventMatches.Match[] GetTeamEventMatches(string teamKey, string eventKey)
        {
            var teamEventMatchesToReturn = new List<TeamEventMatches.Match>();
            string teamNum = teamKey.Substring(4);
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "MatchesAt");
            string fileLines = File.ReadAllText(path);
            teamEventMatchesToReturn =
                    JsonConvert.DeserializeObject<List<TeamEventMatches.Match>>(path);
            return teamEventMatchesToReturn.ToArray();
        }

        public static TeamEvents.Event[] GetTeamEvents(string teamKey, int year)
        {
            var teamEventsToReturn = new List<TeamEvents.Event>();
            var teamEventMatchesToReturn = new List<TeamEventMatches.Match>();
            string teamNum = teamKey.Substring(4);
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "EventsDuring.html");
            string fileLines = File.ReadAllText(path);
            teamEventsToReturn = JsonConvert.DeserializeObject<List<TeamEvents.Event>>(path);
            return teamEventsToReturn.ToArray();
        }

        public static TeamHistoryAwards.Award[] GetTeamHistoricalAwards(string teamKey)
        {
            var teamHistoricalAwardsToReturn = new List<TeamHistoryAwards.Award>();
            string teamNum = teamKey.Substring(4);
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "HistoricalAwards.html");
            string fileLines = File.ReadAllText(path);
            teamHistoricalAwardsToReturn =
                    JsonConvert.DeserializeObject<List<TeamHistoryAwards.Award>>(path);
            return teamHistoricalAwardsToReturn.ToArray();
        }

        public static TeamHistoryEvents.Event[] GetTeamHistoryEvents(string teamKey)
        {
            var teamHistoricalEventsToReturn = new List<TeamHistoryEvents.Event>();
            string teamNum = teamKey.Substring(4);
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "HistoricalEvents.html");
            string fileLines = File.ReadAllText(path);
            teamHistoricalEventsToReturn =
                   JsonConvert.DeserializeObject<List<TeamHistoryEvents.Event>>(fileLines);
            return teamHistoricalEventsToReturn.ToArray();
        }

        /// <summary>
        ///     Provides general information for any FRC team
        ///     teamKey Format Example : "frc3710"
        /// </summary>
        /// <param name="teamKey"></param>
        /// <returns></returns>
        public static TeamInformation GetTeamInformation(string teamKey)
        {
            var teamInformationToReturn = new TeamInformation();
            string teamNum = teamKey.Substring(4);
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "Info.html");
            teamInformationToReturn = JsonConvert.DeserializeObject<TeamInformation>(path);
            return teamInformationToReturn;
        }

        public static TeamMedia.MediaLocation[] GetTeamMediaLocations(string teamKey, int year)
        {
            var teamMediaLocationsToReturn = new List<TeamMedia.MediaLocation>();
            string teamNum = teamKey.Substring(4);
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "MediaLocationsDuring");
            string fileLines = File.ReadAllText(path);
            teamMediaLocationsToReturn =
                    JsonConvert.DeserializeObject<List<TeamMedia.MediaLocation>>(fileLines);
            return teamMediaLocationsToReturn.ToArray();
        }
    }
}