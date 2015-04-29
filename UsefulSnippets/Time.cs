using System;
using System.Globalization;

namespace UsefulSnippets
{
    public class Time
    {
        public static string GetCurrentTime()
        {
            string time = DateTime.Now.ToString("hh:mm:ss tt", DateTimeFormatInfo.InvariantInfo);
            return time;
        }
    }
}
