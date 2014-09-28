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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace FRC_Scouting_V2.UIs
{
    //@author xNovax
    public partial class Aerial_Assist_Scouting_UI_New : UserControl
    {
        public Aerial_Assist_Scouting_UI_New()
        {
            InitializeComponent();
        }

        public void BlankPanel()
        {
            Graphics clearPanelGraphics = startingLocationPanel.CreateGraphics();
            clearPanelGraphics.FillRectangle(Brushes.Silver, 0, 0, 258, 191);
            clearPanelGraphics.Dispose();
            PlotInitialLines();
        }

        public void PlotInitialLines()
        {
            var blackpen = new Pen(Color.Black, 4);
            var fineBluePen = new Pen(Color.Blue, 2);
            var fineWhitePen = new Pen(Color.White, 2);
            var fineRedPen = new Pen(Color.Red, 2);
            Graphics initGraphics = startingLocationPanel.CreateGraphics();

            //Drawing square around the outside edge
            initGraphics.DrawRectangle(blackpen, 0, 0, 258, 191);

            //Drawing field lines
            initGraphics.DrawRectangle(fineBluePen, 4, 4, 76, 183);
            initGraphics.DrawRectangle(fineWhitePen, 84, 4, 92, 183);
            initGraphics.DrawRectangle(fineRedPen, 180, 4, 76, 183);
            initGraphics.DrawLine(blackpen, 129, 0, 129, 191);
            initGraphics.Dispose();
        }

        private void Aerial_Assist_Scouting_UI_2_Load(object sender, EventArgs e)
        {
            
        }

        private void startingLocationPanel_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
