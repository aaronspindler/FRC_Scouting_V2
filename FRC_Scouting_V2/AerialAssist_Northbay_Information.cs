using System;
using FRC_Scouting_V2.Properties;

namespace FRC_Scouting_V2
{
    public partial class AerialAssist_Northbay_Information : GeneralFormTemplate.GeneralFormTemplate
    {
        //@author xNovax

        //Variables
        private readonly Random gen = new Random();

        private int previousNum;
        private int randomNum = 100;
        private string sponsorLevel;
        private string sponsorName;

        public AerialAssist_Northbay_Information()
        {
            InitializeComponent();
        }

        private void AerialAssist_Northbay_Information_Load(object sender, EventArgs e)
        {
            randomNum = gen.Next(13);
            previousNum = randomNum;
            UpdateSponsor();

            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            randomNum = gen.Next(13);

            if (randomNum != previousNum)
            {
                UpdateSponsor();
            }
            else
            {
                randomNum = gen.Next(13);
                UpdateSponsor();
            }
            previousNum = randomNum;
        }

        public void UpdateSponsor()
        {
            switch (randomNum)
            {
                case 0:
                    sponsorPictureBox.Image = Resources.fednor_platinum_northbay_2014;
                    sponsorName = ("FedNor");
                    sponsorLevel = ("Platinum");
                    break;

                case 1:
                    sponsorPictureBox.Image = Resources.redpath_platinum_northbay_2014;
                    sponsorName = ("RedPath");
                    sponsorLevel = ("Platinum");
                    break;

                case 2:
                    sponsorPictureBox.Image = Resources.nipu_platinum_northbay_2014;
                    sponsorName = ("Nipissing University");
                    sponsorLevel = ("Platinum");
                    break;

                case 3:
                    sponsorPictureBox.Image = Resources.atlascopco_gold_northbay_2014;
                    sponsorName = ("Atlas Copco");
                    sponsorLevel = ("Gold");
                    break;

                case 4:
                    sponsorPictureBox.Image = Resources.twg_gold_northbay_2014;
                    sponsorName = ("twg* Communications");
                    sponsorLevel = ("Gold");
                    break;

                case 5:
                    sponsorPictureBox.Image = Resources.ontario_silver_northbay_2014;
                    sponsorName = ("Ontario | Northern Ontario Heritage Fund Corporation");
                    sponsorLevel = ("Silver");
                    break;

                case 6:
                    sponsorPictureBox.Image = Resources.forbetteorforworse_silver_northbay_2014;
                    sponsorName = ("For Better for Worse");
                    sponsorLevel = ("Silver");
                    break;

                case 7:
                    sponsorPictureBox.Image = Resources.canadore_silver_northbay_2014;
                    sponsorName = ("Canadore College");
                    sponsorLevel = ("Silver");
                    break;

                case 8:
                    sponsorPictureBox.Image = Resources.stantec_bronze_northbay_2014;
                    sponsorName = ("Stantec");
                    sponsorLevel = ("Bronze");
                    break;

                case 9:
                    sponsorPictureBox.Image = Resources.north_bay_strategicpartner_northbay_2014;
                    sponsorName = ("North Bay");
                    sponsorLevel = ("Strategic Partner");
                    break;

                case 10:
                    sponsorPictureBox.Image = Resources.nearnorth_strategicpartner_northbay_2014;
                    sponsorName = ("Near North District School Board");
                    sponsorLevel = ("Strategic Partner");
                    break;

                case 11:
                    sponsorPictureBox.Image = Resources.metso_inkind_northbay_2014;
                    sponsorName = ("Metso Minerals");
                    sponsorLevel = ("In Kind");
                    break;

                case 12:
                    sponsorPictureBox.Image = Resources.astowing_inkind_northbay_2014;
                    sponsorName = ("A&S Towing");
                    sponsorLevel = ("In Kind");
                    break;

                case 13:
                    sponsorPictureBox.Image = Resources.sms_inkind_northbay_2014;
                    sponsorName = ("SMS Rents");
                    sponsorLevel = ("In Kind");
                    break;
            }
            sponsorLevelDisplayLabel.Text = ("Sponsor Level: " + sponsorLevel);
            sponsorNameDisplayLabel.Text = ("Sponsor Name: " + sponsorName);
        }
    }
}