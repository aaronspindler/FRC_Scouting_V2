﻿//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2014 FRC_Scouting_V2

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FRC_Scouting_V2.Models;

namespace FRC_Scouting_V2
{
    public class RecycleRush_Scout_Match
    {
        //General Information
        public List<RecycleRush_Stack> Stacks = new List<RecycleRush_Stack>();
        public string Author { get; set; }

        public string TimeCreated { get; set; }

        public string UniqueID { get; set; }

        public int Team_Number { get; set; }

        public string Team_Name { get; set; }

        public int Match_Number { get; set; }

        public string scoutingPosition { get; set; }

        public Boolean Robot_Dead { get; set; }

        //Autonomous
        public int Auto_Starting_X { get; set; }

        public int Auto_Starting_Y { get; set; }

        public Boolean Auto_Drive_To_Autozone { get; set; }

        public Boolean Auto_Can_Burgeled { get; set; }

        public int Auto_Cans_Grabbed { get; set; }

        public Boolean Auto_Robot_Set { get; set; }

        public Boolean Auto_Tote_Set { get; set; }

        public Boolean Auto_Bin_Set { get; set; }

        public Boolean Auto_Stacked_Tote_Set { get; set; }

        public int Auto_Acquired_Step_Bins { get; set; }

        public int Auto_Fouls { get; set; }

        public Boolean Auto_Did_Nothing { get; set; }

        //Teleoperated
        public Boolean Tele_Tote_Pickup_Upright { get; set; }

        public Boolean Tele_Tote_Pickup_Upside_Down { get; set; }

        public Boolean Tele_Tote_Pickup_Sideways { get; set; }

        public Boolean Tele_Bin_Pickup_Upright { get; set; }

        public Boolean Tele_Bin_Pickup_Upside_Down { get; set; }

        public Boolean Tele_Bin_Pickup_Sideways { get; set; }

        public Boolean Tele_Human_Station_Load_Totes { get; set; }

        public Boolean Tele_Human_Station_Stack_Totes { get; set; }

        public Boolean Tele_Human_Station_Insert_Litter { get; set; }

        public int Tele_Human_Throwing_Litter { get; set; }

        public int Tele_Pushed_Litter_To_Landfill { get; set; }

        public int Tele_Fouls { get; set; }

        public string Comments { get; set; }

        //Coopertition
        public Boolean Coopertition_Set { get; set; }

        public Boolean Coopertition_Stack { get; set; }

        //Scoring
        public int Aprox_Robots_Auton_Score { get; set; }

        public int Aprox_Robots_Teleop_Score { get; set; }

        public int Aprox_Robots_Coopertition_Score { get; set; }

        public int Aprox_Robots_Total_Score { get; set; }

        //Other
        public int Driver_Rating { get; set; }
    }
}