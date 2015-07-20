using System;
using System.IO;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using TheBlueAlliance.Models;

namespace TheBlueAlliance
{
    public class Matches
    {
        public static MatchInformation_2015.Match GetMatchInformation2015(string matchKey)
        {
            if (GetMatchInformationJsonData(matchKey) != null)
            {
                return JsonConvert.DeserializeObject<MatchInformation_2015.Match>(GetMatchInformationJsonData(matchKey));
            }

            return null;
        }

        private static string GetMatchInformationJsonData(string matchKey)
        {
            try
            {
                var wc = new WebClient();
                wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
                string downloadedData = wc.DownloadString("http://www.thebluealliance.com/api/v2/match/" + matchKey);
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json"))
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json");
                }
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\");
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json", downloadedData);
                return downloadedData;
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
                return GetCachedMatchInformationJson(matchKey);
            }
        }

        private static string GetCachedMatchInformationJson(string matchKey)
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json"))
            {
                return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json");
            }
            return null;
        }
    }
}