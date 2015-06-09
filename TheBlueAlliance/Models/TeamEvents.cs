namespace TheBlueAlliance.Models
{
    public class TeamEvents
    {
        public class Alliance
        {
            public object[] declines { get; set; }
            public string[] picks { get; set; }
        }

        public class Event
        {
            public string key { get; set; }
            public string website { get; set; }
            public bool official { get; set; }
            public string end_date { get; set; }
            public string name { get; set; }
            public string short_name { get; set; }
            public object facebook_eid { get; set; }
            public object event_district_string { get; set; }
            public string venue_address { get; set; }
            public int event_district { get; set; }
            public string location { get; set; }
            public string event_code { get; set; }
            public int year { get; set; }
            public Webcast[] webcast { get; set; }
            public Alliance[] alliances { get; set; }
            public string event_type_string { get; set; }
            public string start_date { get; set; }
            public int event_type { get; set; }
        }

        public class Webcast
        {
            public string type { get; set; }
            public string channel { get; set; }
            public string file { get; set; }
        }
    }
}