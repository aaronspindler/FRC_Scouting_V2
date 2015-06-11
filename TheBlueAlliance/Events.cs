using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using TheBlueAlliance.Models;

namespace TheBlueAlliance
{
    public class Events
    {
        /// <summary>
        ///     Provides information for an event
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
                string url = ("http://www.thebluealliance.com/api/v2/event/" + eventCode);
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
            EventAwards.Award[] eventAwardsToReturn = dataList.ToArray();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                string url = ("http://www.thebluealliance.com/api/v2/event/" + eventKey + "/awards");
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
            EventMatches.Match[] eventMatchesToReturn = dataList.ToArray();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                string url = ("http://www.thebluealliance.com/api/v2/event/" + eventKey + "/matches");
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
                string url = ("http://www.thebluealliance.com/api/v2/event/" + eventKey + "/rankings");
                var dataList = JsonConvert.DeserializeObject<List<List<object>>>(wc.DownloadString(url));

                for (int i = 1; i < dataList.Count; i++)
                {
                    var teamToAdd = new EventRankings.Team
                    {
                        Rank = Convert.ToInt32(dataList.ToArray()[i][0]),
                        Team_Number = Convert.ToInt32(dataList.ToArray()[i][1]),
                        Qual_Average = Convert.ToDouble(dataList.ToArray()[i][2]),
                        Auto = Convert.ToInt32(dataList.ToArray()[i][3]),
                        Container = Convert.ToInt32(dataList.ToArray()[i][4]),
                        Coopertition = Convert.ToInt32(dataList.ToArray()[i][5]),
                        Litter = Convert.ToInt32(dataList.ToArray()[i][6]),
                        Tote = Convert.ToInt32(dataList.ToArray()[i][7]),
                        Played = Convert.ToInt32(dataList.ToArray()[i][8])
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

        public static Models.Events.Event[] GetEvents(int year)
        {
            var dataList = new List<Models.Events.Event>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                string url = ("http://www.thebluealliance.com/api/v2/events/" + year);
                dataList = JsonConvert.DeserializeObject<List<Models.Events.Event>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return dataList.ToArray();
        }

        public static EventTeams.Team[] GetEventTeamsList(string eventKey)
        {
            var teamList = new List<EventTeams.Team>();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                string url = ("http://www.thebluealliance.com/api/v2/event/" + eventKey + "/teams");
                teamList = JsonConvert.DeserializeObject<List<EventTeams.Team>>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamList.ToArray();
        }
    }
}