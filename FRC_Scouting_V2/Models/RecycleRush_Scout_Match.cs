using System;

namespace FRC_Scouting_V2
{
    public class RecycleRush_Scout_Match
    {
        //General Information
        public string Author { get; set; }
        public DateTime TimeCreated { get; set; }
        public string UniqueID { get; set; }

        public int Team_Number { get; set; }
        public string Team_Name { get; set; }
        public string Time_Created { get; set; }
        public int Match_Number { get; set; }
        public Boolean Robot_Dead { get; set; }

        //Autonomous
        public Boolean Auto_Drive_To_Autozone { get; set; }
        public Boolean Auto_Did_Nothing { get; set; }
        public int Auto_Starting_X { get; set; }
        public int Auto_Starting_Y { get; set; }
        public int Auto_Yellow_Stacked_Totes { get; set; }
        public int Auto_Yellow_Moved_Totes { get; set; }
        public int Auto_Acquired_Step_Bins { get; set; }
        public int Auto_Moved_Bins { get; set; }
        public int Auto_Fouls { get; set; }
        public int Auto_Interference { get; set; }

        //Teleoperated
        public Boolean Tele_Picked_Up_Ground_Upright_Totes { get; set; }
        public Boolean Tele_Picked_Up_Upside_Down_Totes { get; set; }
        public Boolean Tele_Picked_Up_Sideways_Totes { get; set; }
        public Boolean Tele_Picked_Up_Human_Station_Totes { get; set; }
        public Boolean Tele_Picked_Up_Sideways_Bins { get; set; }
        public Boolean Tele_Picked_Up_Upright_Bins { get; set; }
        public Boolean Tele_Picked_Up_Center_Step_Bins { get; set; }
        public Boolean Tele_Pushed_Litter { get; set; }
        public Boolean Tele_Placed_In_Container_Litter { get; set; }
        public Boolean Human_Throwing_Noodles { get; set; }
        public int Tele_Fouls { get; set; }
        public Boolean Tele_Knocked_Over_Stacks { get; set; }
               // X, Y, Height
        public int[][][] Tele_Stacks { get; set; }
        public Boolean[] Tele_Stacks_With_Bin { get; set; }

        public string Comments { get; set; }

        //Other
        public int Final_Score { get; set; }
        public int Driver_Rating { get; set; }
    }
}