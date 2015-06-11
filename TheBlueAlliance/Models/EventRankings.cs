namespace TheBlueAlliance.Models
{
    public class EventRankings
    {
        public class Team
        {
            public int Rank { get; set; }
            public int Team_Number { get; set; }
            public double Qual_Average { get; set; }
            public int Auto { get; set; }
            public int Container { get; set; }
            public int Coopertition { get; set; }
            public int Litter { get; set; }
            public int Tote { get; set; }
            public int Played { get; set; }
        }
    }
}