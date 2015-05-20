namespace UsefulSnippets.TheBlueAlliance.Models
{
    internal class Events
    {
        public class EventList
        {
            public Event[] events { get; set; }
        }

        public class Event
        {
            public string key { get; set; }

            public string website { get; set; }

            public bool official { get; set; }

            public string end_date { get; set; }

            public string name { get; set; }

            public string short_name { get; set; }

            public string facebook_eid { get; set; }

            public string event_district_string { get; set; }

            public string venue_address { get; set; }

            public int? event_district { get; set; }

            public string location { get; set; }

            public string event_code { get; set; }

            public int year { get; set; }

            public object[] webcast { get; set; }

            public object[] alliances { get; set; }

            public string event_type_string { get; set; }

            public string start_date { get; set; }

            public int event_type { get; set; }
        }
    }
}