using Newtonsoft.Json;
using System;
using System.Net;
using System.Reflection;
using UsefulSnippets.TheBlueAlliance.Models;

namespace UsefulSnippets.TheBlueAlliance
{
    public class Getters
    {
        /*
         * +-------------------------+----------------+---------+--------------------+---------+
           | Method                  | Code Finished? | Tested? | Fully Functioning? | Broken? |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetEventInformation     | true           | true    | true               | false   |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetEventAwards          | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetEventMatches         | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetEventRankings        | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetEvents               | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetEventTeamsList       | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetMatchInformation     | true           | true    | true               | false   |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetTeamEventAwards      | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetTeamEventMatches     | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetTeamEvents           | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetTeamHistoricalAwards | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetTeamHistoryEvents    | false          | false   | false              | true    |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetTeamInformation      | true           | true    | true               | false   |
           +-------------------------+----------------+---------+--------------------+---------+
           | GetTeamMediaLocations   | false          | false   | false              |         |
           +-------------------------+----------------+---------+--------------------+---------+
         */

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

        //Broken
        public static EventAwards GetEventAwards(string eventCode)
        {
            var eventAwardsToReturn = new EventAwards();

            return eventAwardsToReturn;
        }

        //Broken
        public static EventMatches GetEventMatches(string eventCode)
        {
            var eventMatchesToReturn = new EventMatches();

            return eventMatchesToReturn;
        }

        //Broken
        public static EventRankings GetEventRankings(string eventCode)
        {
            var eventRankingsToReturn = new EventRankings();

            return eventRankingsToReturn;
        }

        //Broken
        public static Events GetEvents(int year)
        {
            var eventListToReturn = new Events();
            
            return eventListToReturn;
        }

        //Broken
        public static EventTeams GetEventTeamsList(string eventCode)
        {
            var eventTeamListToReturn = new EventTeams();

            return eventTeamListToReturn;
        }

        public static MatchInformation.Match GetMatchInformation(string matchCode)
        {
            var matchToReturn = new MatchInformation.Match();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("http://www.thebluealliance.com/api/v2/match/" + matchCode);
                matchToReturn = JsonConvert.DeserializeObject<MatchInformation.Match>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return matchToReturn;
        }

        //Broken
        public static TeamEventAwards GetTeamEventAwards(string teamKey, string eventKey)
        {
            var teamEventsToReturn = new TeamEventAwards();
            
            return teamEventsToReturn;
        }

        //Broken
        public static TeamEventMatches GetTeamEventMatches(string teamKey, string eventKey)
        {
            var teamEventMatchesToReturn = new TeamEventMatches();
            
            return teamEventMatchesToReturn;
        }   

        //Broken
        public static TeamEvents GetTeamEvents(string teamKey, int year)
        {
            var teamEventsToReturn = new TeamEvents();
            
            return teamEventsToReturn;
        }

        //Broken
        public static TeamHistoryAwards GetTeamHistoricalAwards(string teamKey)
        {
            var teamHistoricalAwardsToReturn = new TeamHistoryAwards();

            return teamHistoricalAwardsToReturn;
        }

        //Broken
        public static TeamHistoryEvents GetTeamHistoryEvents(string teamKey)
        {
            var teamHistoricalEventsToReturn = new TeamHistoryEvents();
           
            return teamHistoricalEventsToReturn;
        }

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

        //Broken
        public static TeamMedia GetTeamMediaLocations(string teamKey, int year)
        {
            var teamMediaLocationsToReturn = new TeamMedia();
            
            return teamMediaLocationsToReturn;
        }
    }
}