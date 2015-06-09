namespace TheBlueAlliance.Models
{
    public class TeamMedia
    {
        public class Details
        {
            public string image_partial { get; set; }
        }

        public class MediaLocation
        {
            public string type { get; set; }
            public Details details { get; set; }
            public string foreign_key { get; set; }
        }
    }
}