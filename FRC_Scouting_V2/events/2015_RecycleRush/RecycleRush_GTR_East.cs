using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FRC_Scouting_V2.Events._2015_RecycleRush
{
    public partial class RecycleRush_GTR_East : Form
    {
        //Variables
        private List<string> teamList = new List<string>();
        private Stack undoStack = new Stack();

        public RecycleRush_GTR_East()
        {
            InitializeComponent();
        }

        private void RecycleRush_GTR_East_Load(object sender, EventArgs e)
        {
                //var match = new RecycleRush_Scout_Match();
                //match.Author = "Fred";

                //var serializer = new XmlSerializer(match.GetType());

                //var writer = new StreamWriter("@D:/Temp/myfile.xml");

                //serializer.Serialize(writer.BaseStream, match);
        }
    }
}