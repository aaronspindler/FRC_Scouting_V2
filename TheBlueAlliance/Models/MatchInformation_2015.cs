namespace TheBlueAlliance.Models
{
    public class MatchInformation_2015
    {
        public class Alliances
        {
            public Blue1 blue { get; set; }
            public Red1 red { get; set; }
        }

        public class Blue
        {
            public int tote_count_far { get; set; }
            public int tote_count_near { get; set; }
            public int container_count_level1 { get; set; }
            public int container_count_level2 { get; set; }
            public int container_count_level3 { get; set; }
            public int container_count_level4 { get; set; }
            public int container_count_level5 { get; set; }
            public int container_count_level6 { get; set; }
            public int teleop_points { get; set; }
            public int auto_points { get; set; }
            public int total_points { get; set; }
            public bool tote_set { get; set; }
            public bool container_set { get; set; }
            public int foul_count { get; set; }
            public int container_points { get; set; }
            public int adjust_points { get; set; }
            public int litter_count_unprocessed { get; set; }
            public bool robot_set { get; set; }
            public int litter_count_container { get; set; }
            public int tote_points { get; set; }
            public int foul_points { get; set; }
            public bool tote_stack { get; set; }
            public int litter_count_landfill { get; set; }
            public int litter_points { get; set; }
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
            public int tote_count_far { get; set; }
            public int tote_count_near { get; set; }
            public int container_count_level1 { get; set; }
            public int container_count_level2 { get; set; }
            public int container_count_level3 { get; set; }
            public int container_count_level4 { get; set; }
            public int container_count_level5 { get; set; }
            public int container_count_level6 { get; set; }
            public int teleop_points { get; set; }
            public int auto_points { get; set; }
            public int total_points { get; set; }
            public bool tote_set { get; set; }
            public bool container_set { get; set; }
            public int foul_count { get; set; }
            public int container_points { get; set; }
            public int adjust_points { get; set; }
            public int litter_count_unprocessed { get; set; }
            public bool robot_set { get; set; }
            public int litter_count_container { get; set; }
            public int tote_points { get; set; }
            public int foul_points { get; set; }
            public bool tote_stack { get; set; }
            public int litter_count_landfill { get; set; }
            public int litter_points { get; set; }
        }

        public class Red1
        {
            public int score { get; set; }
            public string[] teams { get; set; }
        }

        public class Score_Breakdown
        {
            public Blue blue { get; set; }
            public string coopertition { get; set; }
            public Red red { get; set; }
            public int coopertition_points { get; set; }
        }
    }
}