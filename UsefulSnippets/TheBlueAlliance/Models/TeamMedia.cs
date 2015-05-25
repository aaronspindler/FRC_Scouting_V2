namespace UsefulSnippets.TheBlueAlliance.Models
{
    public class TeamMedia
    {
        public class MediaLocation
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