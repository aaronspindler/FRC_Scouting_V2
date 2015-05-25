using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Reflection;
using UsefulSnippets.TheBlueAlliance.Models;

namespace UsefulSnippets.TheBlueAlliance
{
    /// <summary>
    /// An abstraction layer between FRC_Scouting_V2 and TheBlueAlliance API
    /// </summary>
    public class Getters
    {
        /* Examples
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetEventInformation("2015onto").name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetMatchInformation("2015onnb_qm64").match_number);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetTeamInformation("frc3710").name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetEventAwards("2014onto")[0].name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetEventMatches("2015onto")[0].match_number);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetEventRankings("2015onto")[1][1]);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetEvents(2015)[0].name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetEventRankings("2015onto")[0].Team_Number);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetEventTeamsList("2015onto")[0].name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetTeamEventAwards("frc3710", "2015onto")[0].name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetTeamEventMatches("frc3710", "2015onto")[0].match_number);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetTeamEvents("frc3710",2015)[0].name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetTeamHistoryEvents("frc3710")[0].name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetTeamHistoricalAwards("frc3710")[0].name);
         *   Console.WriteLine(UsefulSnippets.TheBlueAlliance.Getters.GetTeamMediaLocations("frc254",2015)[0].type);
         */

        /// <summary>
        /// Provides information for an event
        /// </summary>
        /// <param name="eventCode"></param>
        /// <returns></returns>
        public static Event.EventInformation GetEventInformation(string eventCode)
        {
            var eventToReturn = new Event.EventInformation();

            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/event/" + eventCode);
                eventToReturn = JsonConvert.DeserializeObject<Event.EventInformation>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }

            return eventToReturn;
        }

        public static EventAwards.Award[] GetEventAwards(string eventKey)
        {
            var dataList = new List<EventAwards.Award>();
            var eventAwardsToReturn = dataList.ToArray();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/event/" + eventKey + "/awards");
                dataList = JsonConvert.DeserializeObject<List<EventAwards.Award>>(wc.DownloadString(url));
                eventAwardsToReturn = dataList.ToArray();
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return eventAwardsToReturn;
        }

        public static EventMatches.Match[] GetEventMatches(string eventKey)
        {
            var dataList = new List<EventMatches.Match>();
            var eventMatchesToReturn = dataList.ToArray();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/event/" + eventKey + "/matches");
                dataList = JsonConvert.DeserializeObject<List<EventMatches.Match>>(wc.DownloadString(url));
                eventMatchesToReturn = dataList.ToArray();
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return eventMatchesToReturn;
        }

        
        public static EventRankings.Team[] GetEventRankings(string eventKey)
        {
            var teamList = new List<EventRankings.Team>();

            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/event/" + eventKey + "/rankings");
                var dataList = JsonConvert.DeserializeObject<List<List<object>>>(wc.DownloadString(url));

                for (int i = 1; i < dataList.Count; i++)
                {
                    var teamToAdd = new EventRankings.Team
                    {
                        Rank = dataList.ToArray()[i][0],
                        Team_Number = dataList.ToArray()[i][1],
                        Qual_Average = dataList.ToArray()[i][2],
                        Auto = dataList.ToArray()[i][3],
                        Container = dataList.ToArray()[i][4],
                        Coopertition = dataList.ToArray()[i][5],
                        Litter = dataList.ToArray()[i][6],
                        Tote = dataList.ToArray()[i][7],
                        Played = dataList.ToArray()[i][8]
                    };
                    teamList.Add(teamToAdd);
                }
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }

            return teamList.ToArray();
        }

        public static Events.Event[] GetEvents(int year)
        {
            var dataList = new List<Events.Event>();
            var eventListToReturn = dataList.ToArray();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/events/" + year);
                dataList = JsonConvert.DeserializeObject<List<Events.Event>>(wc.DownloadString(url));
                eventListToReturn = dataList.ToArray();
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return eventListToReturn;
        }

        public static EventTeams.Team[] GetEventTeamsList(string eventKey)
        {
            var teamList = new List<EventTeams.Team>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/event/" + eventKey + "/teams");
                teamList = JsonConvert.DeserializeObject<List<EventTeams.Team>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamList.ToArray();
        }

        /// <summary>
        /// Provides match information for a specific match
        /// </summary>
        /// <param name="matchKey"></param>
        /// <returns></returns>
        public static MatchInformation.Match GetMatchInformation(string matchKey)
        {
            var matchToReturn = new MatchInformation.Match();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/match/" + matchKey);
                matchToReturn = JsonConvert.DeserializeObject<MatchInformation.Match>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return matchToReturn;
        }

        public static TeamEventAwards.Award[] GetTeamEventAwards(string teamKey, string eventKey)
        {
            var teamEventAwardsToReturn = new List<TeamEventAwards.Award>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/event/" + eventKey + "/awards");
                teamEventAwardsToReturn = JsonConvert.DeserializeObject<List<TeamEventAwards.Award>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamEventAwardsToReturn.ToArray();
        }

        public static TeamEventMatches.Match[] GetTeamEventMatches(string teamKey, string eventKey)
        {
            var teamEventMatchesToReturn = new List<TeamEventMatches.Match>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/event/" + eventKey + "/matches");
                teamEventMatchesToReturn = JsonConvert.DeserializeObject<List<TeamEventMatches.Match>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamEventMatchesToReturn.ToArray();
        }   

        public static TeamEvents.Event[] GetTeamEvents(string teamKey, int year)
        {
            var teamEventsToReturn = new List<TeamEvents.Event>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey +"/" + year + "/events");
                teamEventsToReturn = JsonConvert.DeserializeObject<List<TeamEvents.Event>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamEventsToReturn.ToArray();
        }

        public static TeamHistoryAwards.Award[] GetTeamHistoricalAwards(string teamKey)
        {
            var teamHistoricalAwardsToReturn = new List<TeamHistoryAwards.Award>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/history/awards");
                teamHistoricalAwardsToReturn = JsonConvert.DeserializeObject<List<TeamHistoryAwards.Award>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamHistoricalAwardsToReturn.ToArray();
        }

        public static TeamHistoryEvents.Event[] GetTeamHistoryEvents(string teamKey)
        {
            var teamHistoricalEventsToReturn = new List<TeamHistoryEvents.Event>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/history/events");
                teamHistoricalEventsToReturn = JsonConvert.DeserializeObject<List<TeamHistoryEvents.Event>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamHistoricalEventsToReturn.ToArray();
        }

        /// <summary>
        /// Provides information for any FRC team
        /// </summary>
        /// <param name="teamKey"></param>
        /// <returns></returns>
        public static TeamInformation GetTeamInformation(string teamKey)
        {
            var teamInformationToReturn = new TeamInformation();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey);
                teamInformationToReturn = JsonConvert.DeserializeObject<TeamInformation>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamInformationToReturn;
        }

        public static TeamMedia.MediaLocation[] GetTeamMediaLocations(string teamKey, int year)
        {
            var teamMediaLocationsToReturn = new List<TeamMedia.MediaLocation>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/team/" + teamKey + "/" + year + "/media");
                teamMediaLocationsToReturn = JsonConvert.DeserializeObject<List<TeamMedia.MediaLocation>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamMediaLocationsToReturn.ToArray();
        }
    }
}