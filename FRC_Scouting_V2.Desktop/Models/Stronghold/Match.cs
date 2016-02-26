#region License
//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2016 FRC_Scouting_V2

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
#endregion

using System;

namespace FRC_Scouting_V2.Models.Stronghold
{
    class Match
    {
        public string author { get; set; }
        public string time_created { get; set; }
        public string uniqueid { get; set; }

        public Field_Element[] field_setup { get; set; }

        public int team_number { get; set; }
        public string team_name { get; set; }

        public int match_number { get; set; }
        public int alliance_colour { get; set; }

        public int[] high_goal { get; set; }
        public int[] low_goal { get; set; }

        public Boolean reach_defence { get; set; }

        public Boolean is_spy { get; set; }

        public Boolean cross_Chevel_de_frise { get; set; }
        public Boolean cross_Drawbridge { get; set; }
        public Boolean cross_Lowbar { get; set; }
        public Boolean cross_Moat { get; set; }
        public Boolean cross_Portcullis { get; set; }
        public Boolean cross_Ramparts { get; set; }
        public Boolean cross_Rock_wall { get; set; }
        public Boolean cross_Rough_terrain { get; set; }

        public Boolean challenge { get; set; }
        public Boolean scale { get; set; }

        public int blue_score { get; set; }
        public int red_score { get; set; }
        public int[] fouls { get; set; }
        public int driver_rating { get; set; }
        public Boolean robot_dead { get; set; }

        public string comments { get; set; }
    }
}
