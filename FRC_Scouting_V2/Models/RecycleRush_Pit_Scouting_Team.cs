using System;

namespace FRC_Scouting_V2
{
    class RecycleRush_Pit_Scouting_Team
    {
        public string Author { get; set; }
        public string Last_Editor { get; set; }
        public DateTime Time_Created { get; set; }
        public string UniqueID { get; set; }

        public int Team_Number { get; set; }
        public string Team_Name { get; set; }
        public string Team_Website { get; set; }

        public double Robot_Weight { get; set; }
        public double Robot_Height { get; set; }

        public string Drive_Train { get; set; }

        public Boolean Can_Move_Totes { get; set; }
        public Boolean Can_Move_Bins { get; set; }
        public Boolean Can_Acquire_Bins { get; set; }

        public Boolean Needs_Special_Starting_Position { get; set; }
        public int Special_Starting_Position_X { get; set; }
        public int Special_Starting_Position_Y { get; set; }

        public int Stack_Capacity { get; set; }
        public Boolean Can_It_Bin { get; set; }

        public Boolean Human_Tote_Loading { get; set; }
        public Boolean Human_Litter_Loading { get; set; }
        public Boolean Human_Litter_Throwing { get; set; }

        public string Know_Weaknesses { get; set; }
        public string Known_Strengths { get; set; }

        public string Comments { get; set; }

        public byte[] Front_Picture { get; set; }
        public byte[] Left_Side_Picture { get; set; }
        public byte[] Left_Isometric_Picture { get; set; }
        public byte[] Right_Side_Picture { get; set; }
        public byte[] Right_Isometric_Picture { get; set; }
        public byte[] Other_Picture { get; set; }
    }
}
