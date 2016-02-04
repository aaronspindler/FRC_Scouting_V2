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
namespace FRC_Scouting_V2
{
    public class RecycleRush_Pit_Scouting_Team
    {
        public string Author { get; set; }

        public string Time_Created { get; set; }

        public string UniqueID { get; set; }

        public int Team_Number { get; set; }

        public string Team_Name { get; set; }

        public string Drive_Train { get; set; }

        public int Number_Of_Robots { get; set; }

        public bool Does_It_have_A_Ramp { get; set; }

        public bool Can_It_Manipulate_Totes { get; set; }

        public bool Can_It_Manipulate_Bins { get; set; }

        public bool Can_It_Manipulate_Litter { get; set; }

        public bool Needs_Special_Starting_Position { get; set; }

        public string Special_Starting_Position { get; set; }

        public int Max_Stack_Height { get; set; }

        public int Max_Bin_On_Stack_Height { get; set; }

        public bool Human_Tote_Loading { get; set; }

        public bool Human_Litter_Loading { get; set; }

        public bool Human_Litter_Throwing { get; set; }

        public string Comments { get; set; }

        public byte[] Front_Picture { get; set; }

        public byte[] Left_Side_Picture { get; set; }

        public byte[] Left_Isometric_Picture { get; set; }

        public byte[] Other_Picture { get; set; }
    }
}