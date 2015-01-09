//*********************************License***************************************
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

using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;

namespace FRC_Scouting_V2
{
    public partial class RecycleRush_Field : UserControl
    {
        public RecycleRush_Field()
        {
            InitializeComponent();
        }

        public void PlotInitialLines()
        {
            var blackpen = new Pen(Color.Black, 4);
            var fineBlackPen = new Pen(Color.Black, 2);
            var fineBluePen = new Pen(Color.Blue, 2);
            var fineWhitePen = new Pen(Color.White, 2);
            var fineRedPen = new Pen(Color.Red, 2);
            var graphics = fieldPanel.CreateGraphics();

            //graphics.DrawRectangle(blackpen, 0, 0, 708, 352);
            //graphics.FillRectangle(Brushes.DarkBlue, 2, 2, 704, 348);
            //graphics.FillRectangle(Brushes.Red, 351, 2, 355, 348);
            var fieldImage = Resources.ResourceManager.GetObject("RecycleRushField");
            graphics.DrawImage((Image) fieldImage, 0,0);
            graphics.Dispose();
        }

        private void fieldPanel_Paint(object sender, PaintEventArgs e)
        {
            PlotInitialLines();
        }
    }
}
