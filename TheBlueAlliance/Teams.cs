using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using TheBlueAlliance.Models;
using TheBlueAllianceOffline;

namespace TheBlueAlliance
{
    public class Teams
    {
        public static TeamEventAwards.Award[] GetTeamEventAwards(string teamKey, string eventKey)
        {
            var teamEventAwardsToReturn = new List<TeamEventAwards.Award>();
            if (InternetTest.internetAvailable)
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id",
                    "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                try
                {
                    string url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/event/" + eventKey + "/awards");
                    teamEventAwardsToReturn =
                        JsonConvert.DeserializeObject<List<TeamEventAwards.Award>>(wc.DownloadString(url));
                }
                catch (Exception webError)
                {
                    Console.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamEventAwardsToReturn = (List<TeamEventAwards.Award>)Convert.ChangeType((TheBlueAllianceOffline.Teams.GetTeamEventAwards(teamKey, eventKey)), typeof(List<TeamEventAwards.Award>));
            }
            return teamEventAwardsToReturn.ToArray();
        }

        public static TeamEventMatches.Match[] GetTeamEventMatches(string teamKey, string eventKey)
        {
            var teamEventMatchesToReturn = new List<TeamEventMatches.Match>();
            if (InternetTest.internetAvailable)
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id",
                    "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                try
                {
                    string url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/event/" + eventKey +
                                  "/matches");
                    teamEventMatchesToReturn =
                        JsonConvert.DeserializeObject<List<TeamEventMatches.Match>>(wc.DownloadString(url));
                }
                catch (Exception webError)
                {
                    Console.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamEventMatchesToReturn = (List<TeamEventMatches.Match>)Convert.ChangeType((TheBlueAllianceOffline.Teams.GetTeamEventMatches(teamKey, eventKey)), typeof(List<TeamEventMatches.Match>));
            }
            
            return teamEventMatchesToReturn.ToArray();
        }

        public static TeamEvents.Event[] GetTeamEvents(string teamKey, int year)
        {
            var teamEventsToReturn = new List<TeamEvents.Event>();
            if (InternetTest.internetAvailable)
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id",
                    "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                try
                {
                    string url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/" + year + "/events");
                    teamEventsToReturn = JsonConvert.DeserializeObject<List<TeamEvents.Event>>(wc.DownloadString(url));
                }
                catch (Exception webError)
                {
                    Console.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamEventsToReturn = (List<TeamEvents.Event>)Convert.ChangeType((TheBlueAllianceOffline.Teams.GetTeamEvents(teamKey, year)), typeof(List<TeamEvents.Event>));
            }
            return teamEventsToReturn.ToArray();
        }

        public static TeamHistoryAwards.Award[] GetTeamHistoricalAwards(string teamKey)
        {
            var teamHistoricalAwardsToReturn = new List<TeamHistoryAwards.Award>();
            if (InternetTest.internetAvailable)
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id",
                    "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                try
                {
                    string url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/history/awards");
                    teamHistoricalAwardsToReturn =
                        JsonConvert.DeserializeObject<List<TeamHistoryAwards.Award>>(wc.DownloadString(url));
                }
                catch (Exception webError)
                {
                    Console.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamHistoricalAwardsToReturn = (List<TeamHistoryAwards.Award>)Convert.ChangeType((TheBlueAllianceOffline.Teams.GetTeamHistoricalAwards(teamKey)), typeof(List<TeamHistoryAwards.Award>));
            }
            return teamHistoricalAwardsToReturn.ToArray();
        }

        public static TeamHistoryEvents.Event[] GetTeamHistoryEvents(string teamKey)
        {
            var teamHistoricalEventsToReturn = new List<TeamHistoryEvents.Event>();
            if (InternetTest.internetAvailable)
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id",
                    "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                try
                {
                    string url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/history/events");
                    teamHistoricalEventsToReturn =
                        JsonConvert.DeserializeObject<List<TeamHistoryEvents.Event>>(wc.DownloadString(url));
                }
                catch (Exception webError)
                {
                    Console.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamHistoricalEventsToReturn = (List<TeamHistoryEvents.Event>)Convert.ChangeType((TheBlueAllianceOffline.Teams.GetTeamHistoryEvents((teamKey))), typeof(List<TeamHistoryEvents.Event>));
            }
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
            if (InternetTest.internetAvailable)
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id",
                    "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                try
                {
                    string url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey);
                    teamInformationToReturn = JsonConvert.DeserializeObject<TeamInformation>(wc.DownloadString(url));
                }
                catch (Exception webError)
                {
                    Console.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamInformationToReturn = (TeamInformation)Convert.ChangeType((TheBlueAllianceOffline.Teams.GetTeamInformation(teamKey)), typeof(TeamInformation));
            }
            return teamInformationToReturn;
        }

        public static TeamMedia.MediaLocation[] GetTeamMediaLocations(string teamKey, int year)
        {
            var teamMediaLocationsToReturn = new List<TeamMedia.MediaLocation>();
            if (InternetTest.internetAvailable)
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id",
                    "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                try
                {
                    string url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/" + year + "/media");
                    teamMediaLocationsToReturn =
                        JsonConvert.DeserializeObject<List<TeamMedia.MediaLocation>>(wc.DownloadString(url));
                }
                catch (Exception webError)
                {
                    Console.WriteLine("Error Message: " + webError.Message);
                }
            }
            else
            {
                teamMediaLocationsToReturn = (List<TeamMedia.MediaLocation>)Convert.ChangeType((TheBlueAllianceOffline.Teams.GetTeamMediaLocations(teamKey, year)), typeof(List<TeamMedia.MediaLocation>));
            }
            return teamMediaLocationsToReturn.ToArray();
        }
    }
}