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
using System.Drawing;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;

namespace FRC_Scouting_V2
{
    public partial class RecycleRush_Field : UserControl
    {
        private int startingLocX = 0;
        private int startingLocY = 0;

        public RecycleRush_Field()
        {
            InitializeComponent();
            fieldTypeComboBox.SelectedIndex = 0;
            PlotInitialImage();
        }

        private void fieldTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            PlotInitialImage();
        }

        private void PlotInitialImage()
        {
            try
            {
                switch (fieldTypeComboBox.SelectedIndex)
                {
                    case 0:
                        fieldPictureBox.Image = Resources.RecycleRush_2015_No_Items;
                        break;
                    case 1:
                        fieldPictureBox.Image = Resources.RecycleRush_2015_With_Items;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void fieldPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            startingLocX = e.X - 2;
            startingLocY = e.Y - 2;
        }

        private void fieldPictureBox_Paint(object sender, PaintEventArgs e)
        {
            PlotInitialImage();
            var blackpen = new Pen(Color.Black, 2);
            e.Graphics.DrawRectangle(blackpen, startingLocX, startingLocY, 8, 8);
        }

        public int getX()
        {
            return startingLocX;
        }

        public int getY()
        {
            return startingLocY;
        }
    }
}
