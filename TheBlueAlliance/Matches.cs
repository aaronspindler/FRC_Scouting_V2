using System;
using System.Net;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using TheBlueAlliance.Models;

namespace TheBlueAlliance
{
    public class Matches
    {
        /// <summary>
        ///     Provides match information for a specific match
        /// </summary>
        /// <param name="matchKey"></param>
        /// <returns></returns>
        public static MatchInformation.Match GetMatchInformation(string matchKey)
        {
            var matchToReturn = new MatchInformation.Match();
            if (InternetTest.internetAvailable)
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                try
                {
                    string url = ("http://www.thebluealliance.com/api/v2/match/" + matchKey);
                    matchToReturn = JsonConvert.DeserializeObject<MatchInformation.Match>(wc.DownloadString(url));
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
                    string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + matchKey + "MatchInfo.html");
                    string fileLines = File.ReadAllText(path);
                    matchToReturn = JsonConvert.DeserializeObject<MatchInformation.Match>(fileLines);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error Message: " + exception.Message);
                }
            }
            return matchToReturn;
        }
    }
}