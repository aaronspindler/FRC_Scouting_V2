using System;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            var settings = new PropertieSettings();
            propertyGrid.SelectedObject = settings;
        }
    }

    internal class PropertieSettings
    {
        private string Username { get; set; }
    }
}