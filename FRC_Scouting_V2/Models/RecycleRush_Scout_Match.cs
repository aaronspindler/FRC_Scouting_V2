using System;
using System.Collections.Generic;
using FRC_Scouting_V2.Models;

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

        public int Match_Number { get; set; }
        public Boolean Robot_Dead { get; set; }

        //Autonomous
        public int Auto_Starting_X { get; set; }
        public int Auto_Starting_Y { get; set; }
        public Boolean Auto_Drive_To_Autozone { get; set; }
        public Boolean Auto_Robot_Set { get; set; }
        public Boolean Auto_Tote_Set { get; set; }
        public Boolean Auto_Bin_Set { get; set; }
        public Boolean Auto_Stacked_Tote_Set { get; set; }
        public int Auto_Acquired_Step_Bins { get; set; }
        public int Auto_Fouls { get; set; }
        public Boolean Auto_Did_Nothing { get; set; }
        

        //Teleoperated
        public Boolean Tele_Tote_Pickup_Upright { get; set; }
        public Boolean Tele_Tote_Pickup_Upside_Down{ get; set; }
        public Boolean Tele_Tote_Pickup_Sideways { get; set; }
        public Boolean Tele_Bin_Pickup_Upright { get; set; }
        public Boolean Tele_Bin_Pickup_Upside_Down { get; set; }
        public Boolean Tele_Bin_Pickup_Sideways { get; set; }
        public Boolean Tele_Human_Station_Load_Totes { get; set; }
        public Boolean Tele_Human_Station_Stack_Totes { get; set; }
        public Boolean Tele_Human_Station_Insert_Litter { get; set; }
        public Boolean Tele_Human_Throwing_Litter { get; set; }
        public Boolean Tele_Pushed_Litter_To_Landfill { get; set; }
        public List<Recycle_Rush_Stack> Stacks = new List<Recycle_Rush_Stack>(); 
        public string Comments { get; set; }

        //Other
        public int Final_Score_Red { get; set; }
        public int Final_Score_Blue { get; set; }
        public int Driver_Rating { get; set; }
    }
}