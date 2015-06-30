using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TheBlueAllianceOffline.Models;

namespace TheBlueAllianceOffline
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
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + eventCode + ".html");
            String fileLines = File.ReadAllText(path);
            eventToReturn = JsonConvert.DeserializeObject<Event.EventInformation>(fileLines);
            return eventToReturn;
        }

        public static EventAwards.Award[] GetEventAwards(string eventKey)
        {
            var dataList = new List<EventAwards.Award>();
            EventAwards.Award[] eventAwardsToReturn = dataList.ToArray();
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + eventKey + "Awards.html");
            String fileLines = File.ReadAllText(path);
            dataList = JsonConvert.DeserializeObject<List<EventAwards.Award>>(fileLines);
            eventAwardsToReturn = dataList.ToArray();
            return eventAwardsToReturn;
        }

        public static EventMatches.Match[] GetEventMatches(string eventKey)
        {
            var dataList = new List<EventMatches.Match>();
            EventMatches.Match[] eventMatchesToReturn = dataList.ToArray();
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + eventKey + "Matches.html");
            String fileLines = File.ReadAllText(path);
            dataList = JsonConvert.DeserializeObject<List<EventMatches.Match>>(fileLines);
            eventMatchesToReturn = dataList.ToArray();
            return eventMatchesToReturn;
        }

        public static EventRankings.Team[] GetEventRankings(string eventKey)
        {
            var teamList = new List<EventRankings.Team>();
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + eventKey + "Rankings.html");
            String fileLines = File.ReadAllText(path);
            var dataList = JsonConvert.DeserializeObject<List<List<object>>>(fileLines);
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
            return teamList.ToArray();
        }
        
        public static TheBlueAllianceOffline.Models.Events.Event[] GetEvents(int year)
        {
            var dataList = new List<TheBlueAllianceOffline.Models.Events.Event>();
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\DefaultData\\" + year + "YearEvents.html");
            string fileLines = File.ReadAllText(path);
            dataList = JsonConvert.DeserializeObject<List<TheBlueAllianceOffline.Models.Events.Event>>(fileLines);
            return dataList.ToArray();
        }

        public static EventTeams.Team[] GetEventTeamsList(string eventKey)
        {
            var teamList = new List<EventTeams.Team>();
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + eventKey + "Teamlist.html");
            String fileLines = File.ReadAllText(path);
            teamList = JsonConvert.DeserializeObject<List<EventTeams.Team>>(fileLines);
            return teamList.ToArray();
        }   
    }
}