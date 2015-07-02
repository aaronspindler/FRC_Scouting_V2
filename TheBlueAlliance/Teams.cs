﻿using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TheBlueAlliance.Models;

namespace TheBlueAlliance
{
    public class Teams
    {
        public static TeamEventAwards.Award[] GetTeamEventAwards(string teamKey, string eventKey)
        {
            var teamEventAwardsToReturn = new List<TeamEventAwards.Award>();
            if (InternetTest.checkInternet())
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
                try
                {
                    string teamNum = teamKey.Substring(3);
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "AwardsAt" + eventKey + ".html");
                    string fileLines = File.ReadAllText(path);
                    teamEventAwardsToReturn =
                            JsonConvert.DeserializeObject<List<TeamEventAwards.Award>>(fileLines);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Message: " + exception.Message);
                }   
            }
            return teamEventAwardsToReturn.ToArray();
        }

        public static TeamEventMatches.Match[] GetTeamEventMatches(string teamKey, string eventKey)
        {
            var teamEventMatchesToReturn = new List<TeamEventMatches.Match>();
            if (InternetTest.checkInternet())
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
                try
                {
                    string teamNum = teamKey.Substring(3);
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "MatchesAt");
                    string fileLines = File.ReadAllText(path);
                    teamEventMatchesToReturn =
                            JsonConvert.DeserializeObject<List<TeamEventMatches.Match>>(fileLines);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Message: " + exception.Message);
                }
            }
            
            return teamEventMatchesToReturn.ToArray();
        }

        public static TeamEvents.Event[] GetTeamEvents(string teamKey, int year)
        {
            var teamEventsToReturn = new List<TeamEvents.Event>();
            if (InternetTest.checkInternet())
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
                try
                {
                    string teamNum = teamKey.Substring(3);
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "EventsDuring.html");
                    string fileLines = File.ReadAllText(path);
                    teamEventsToReturn = JsonConvert.DeserializeObject<List<TeamEvents.Event>>(fileLines);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Message: " + exception.Message);
                }
            }
            return teamEventsToReturn.ToArray();
        }

        public static TeamHistoryAwards.Award[] GetTeamHistoricalAwards(string teamKey)
        {
            var teamHistoricalAwardsToReturn = new List<TeamHistoryAwards.Award>();
            if (InternetTest.checkInternet())
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
                try
                {
                    string teamNum = teamKey.Substring(3);
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "HistoricalAwards.html");
                    string fileLines = File.ReadAllText(path);
                    teamHistoricalAwardsToReturn =
                            JsonConvert.DeserializeObject<List<TeamHistoryAwards.Award>>(fileLines);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Message: " + exception.Message);
                }
            }
            return teamHistoricalAwardsToReturn.ToArray();
        }

        public static TeamHistoryEvents.Event[] GetTeamHistoryEvents(string teamKey)
        {
            var teamHistoricalEventsToReturn = new List<TeamHistoryEvents.Event>();
            if (InternetTest.checkInternet())
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
                try
                {
                    string teamNum = teamKey.Substring(3);
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "HistoricalEvents.html");
                    string fileLines = File.ReadAllText(path);
                    teamHistoricalEventsToReturn =
                           JsonConvert.DeserializeObject<List<TeamHistoryEvents.Event>>(fileLines);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Message: " + exception.Message);
                }
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
            if (InternetTest.checkInternet())
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
                try
                {
                    string teamNum = teamKey.Substring(3);
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "Info.html");
                    string fileLines = File.ReadAllText(path);
                    teamInformationToReturn = JsonConvert.DeserializeObject<TeamInformation>(fileLines);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Message: " + exception.Message);
                }
            }
            return teamInformationToReturn;
        }

        public static TeamMedia.MediaLocation[] GetTeamMediaLocations(string teamKey, int year)
        {
            var teamMediaLocationsToReturn = new List<TeamMedia.MediaLocation>();
            if (InternetTest.checkInternet())
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
                try
                {
                    string teamNum = teamKey.Substring(3);
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + "Team" + (Convert.ToInt32(teamNum)) + "MediaLocationsDuring");
                    string fileLines = File.ReadAllText(path);
                    teamMediaLocationsToReturn =
                            JsonConvert.DeserializeObject<List<TeamMedia.MediaLocation>>(fileLines);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Message: " + exception.Message);
                }
            }
            return teamMediaLocationsToReturn.ToArray();
        }
    }
}