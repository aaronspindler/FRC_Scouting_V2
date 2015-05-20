namespace UsefulSnippets.TheBlueAlliance.Models
{
    public class TeamEventAwards
    {
        public class Awards
        {
            public Award[] awards { get; set; }
        }

        public class Award
        {
            public string event_key { get; set; }

            public int award_type { get; set; }

            public string name { get; set; }

            public Recipient_List[] recipient_list { get; set; }

            public int year { get; set; }
        }

        public class Recipient_List
        {
            public int team_number { get; set; }

            public object awardee { get; set; }
        }   
    }
}