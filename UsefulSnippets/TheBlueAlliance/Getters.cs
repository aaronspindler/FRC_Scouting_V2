using Newtonsoft.Json;
using System;
using System.Net;
using System.Reflection;
using UsefulSnippets.TheBlueAlliance.Models;

namespace UsefulSnippets.TheBlueAlliance
{
    internal class Getters
    {
        public Event.EventInformation GetEventInformation(string eventCode)
        {
            var eventToReturn = new Event.EventInformation();

            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("www.thebluealliance.com/api/v2/event/" + eventCode);
                eventToReturn = JsonConvert.DeserializeObject<Event.EventInformation>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }

            return eventToReturn;
        }

        public EventAwards.AwardsList GetEventAwards(string eventCode)
        {
            var eventAwardsToReturn = new EventAwards.AwardsList();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("www.thebluealliance.com/api/v2/event/" + eventCode + "/awards");
                eventAwardsToReturn = JsonConvert.DeserializeObject<EventAwards.AwardsList>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return eventAwardsToReturn;
        }

        public EventMatches.EventMatchList GetEventMatches(string eventCode)
        {
            var eventMatchesToReturn = new EventMatches.EventMatchList();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("www.thebluealliance.com/api/v2/event/" + eventCode + "/matches");
                eventMatchesToReturn = JsonConvert.DeserializeObject<EventMatches.EventMatchList>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return eventMatchesToReturn;
        }

        public EventRankings.Rankings GetEventRankings(string eventCode)
        {
            var eventRankingsToReturn = new EventRankings.Rankings();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("www.thebluealliance.com/api/v2/event/" + eventCode + "/rankings");
                eventRankingsToReturn = JsonConvert.DeserializeObject<EventRankings.Rankings>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return eventRankingsToReturn;
        }

        public Events.EventList GetEvents(int year)
        {
            var eventListToReturn = new Events.EventList();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("www.thebluealliance.com/api/v2/events/" + year);
                eventListToReturn = JsonConvert.DeserializeObject<Events.EventList>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return eventListToReturn;
        }

        public EventTeams.EventTeamsList GetEventTeamsList(string eventCode)
        {
            var eventTeamListToReturn = new EventTeams.EventTeamsList();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("www.thebluealliance.com/api/v2/event/" + eventCode + "/teams");
                eventTeamListToReturn = JsonConvert.DeserializeObject<EventTeams.EventTeamsList>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return eventTeamListToReturn;
        }

        public MatchInformation.Match GetMatchInformation(string matchCode)
        {
            var matchToReturn = new MatchInformation.Match();
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                var url = ("www.thebluealliance.com/api/v2/match/" + matchCode);
                matchToReturn = JsonConvert.DeserializeObject<MatchInformation.Match>(wc.DownloadString(url));
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return matchToReturn;
        }


    }
}