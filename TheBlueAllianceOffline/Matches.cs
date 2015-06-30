using System;
using System.Net;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using TheBlueAllianceOffline.Models;

namespace TheBlueAllianceOffline
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
            string path = (AppDomain.CurrentDomain.BaseDirectory + "\\Saves\\TBA\\" + matchKey + "MatchInfo.html");
            string fileLines = File.ReadAllText(path);
            matchToReturn = JsonConvert.DeserializeObject<MatchInformation.Match>(fileLines);
            return matchToReturn;
        }
    }
}