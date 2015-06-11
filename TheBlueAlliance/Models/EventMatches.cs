namespace TheBlueAlliance.Models
{
    public class EventMatches
    {
        public class Alliances
        {
            public Blue1 blue { get; set; }
            public Red1 red { get; set; }
        }

        public class Blue
        {
            public int auto { get; set; }
            public int foul { get; set; }
        }

        public class Blue1
        {
            public int score { get; set; }
            public string[] teams { get; set; }
        }

        public class Match
        {
            public string comp_level { get; set; }
            public int match_number { get; set; }
            public object[] videos { get; set; }
            public object time_string { get; set; }
            public int set_number { get; set; }
            public string key { get; set; }
            public int time { get; set; }
            public Score_Breakdown score_breakdown { get; set; }
            public Alliances alliances { get; set; }
            public string event_key { get; set; }
        }

        public class Red
        {
            public int auto { get; set; }
            public int foul { get; set; }
        }

        public class Red1
        {
            public int score { get; set; }
            public string[] teams { get; set; }
        }

        public class Score_Breakdown
        {
            public Blue blue { get; set; }
            public Red red { get; set; }
        }
    }
}