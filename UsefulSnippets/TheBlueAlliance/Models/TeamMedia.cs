namespace UsefulSnippets.TheBlueAlliance.Models
{
    public class TeamMedia
    {
        public class TeamMediaLocations
        {
            public Media[] MediaLocations { get; set; }
        }

        public class Media
        {
            public string type { get; set; }

            public Details details { get; set; }

            public string foreign_key { get; set; }
        }

        public class Details
        {
            public string image_partial { get; set; }
        }   
    }
}