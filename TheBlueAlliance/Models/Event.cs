namespace TheBlueAlliance.Models
{
    /// <summary>
    ///     Model for information regarding an FRC event
    /// </summary>
    public class Event
    {
        /// <summary>
        ///     Information regarding the picks and declines of an alliance at an FRC event
        /// </summary>
        public class Alliance
        {
            public object[] declines { get; set; }
            public string[] picks { get; set; }
        }

        /// <summary>
        ///     Main model to store information regarding an event
        /// </summary>
        public class EventInformation
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

        /// <summary>
        ///     Information regarding the location and type of a webcast for an event
        /// </summary>
        public class Webcast
        {
            public string type { get; set; }
            public string channel { get; set; }
            public string file { get; set; }
        }
    }
}