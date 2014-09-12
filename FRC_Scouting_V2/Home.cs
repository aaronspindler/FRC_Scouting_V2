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

using FRC_Scouting_V2.Properties;
using FRC_Scouting_V2.Test_Objects;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Home : Form
    {
        //Variables
        private const int SW_HIDE = 0;

        private const int SW_SHOW = 5;
        private readonly UsefulSnippets us = new UsefulSnippets();
        private Boolean isConsoleVisible;

        public Home()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void ShowConsoleWindow()
        {
            IntPtr handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
            }
        }

        public static void HideConsoleWindow()
        {
            IntPtr handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            HideConsoleWindow();
            eventSelector.Items.Add("Aerial Assist | Northbay | 2014");
            eventSelector.Items.Add("Aerial Assist | Rah Cha Cha | 2014");

            if (Settings.Default.firstTimeLoad)
            {
                if (
                    MessageBox.Show(
                        "Since this is the first time you have used this program please take a look at the settings page. This will prevent any headaches when trying to use the program. Do you want to be taken to the settings page now?",
                        "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var settingsPage = new MainSettings();
                    settingsPage.Show();
                }
                Settings.Default.firstTimeLoad = false;
                Settings.Default.Save();
            }
        }

        private void programInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var programInfo = new ProgramInformation();
            programInfo.Show();
        }

        private void resetAllSavedSettingsToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ClearSettings();
        }

        private void fRC3710TeamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var team3710Info = new Team3710Information();
            team3710Info.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void licenseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var li = new License();
            li.Show();
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changeLog = new Changelog();
            changeLog.Show();
        }

        private void eventSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventSelector.SelectedIndex == 0)
            {
                var aaNorthbay2014 = new AerialAssist_Northbay();
                aaNorthbay2014.Show();

                if (Settings.Default.minimizeHomeWentEventLoads)
                {
                    WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                if (eventSelector.SelectedIndex == 1)
                {
                    var aaRahChaCha = new AerialAssist_RahChaCha();
                    aaRahChaCha.Show();

                    if (Settings.Default.minimizeHomeWentEventLoads)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                }
            }
        }

        //Opens up the test form page
        private void eventSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                var testForm = new TestForm();
                testForm.Show();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainSettings = new MainSettings();
            mainSettings.Show();
        }

        private void toggleConsoleWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isConsoleVisible == false)
            {
                ShowConsoleWindow();
                if (Settings.Default.clearConsoleOnToggle)
                {
                    Console.Clear();
                }

                isConsoleVisible = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Closing this window results in closure of the program!");
                Console.WriteLine("To hide console go to Home -> Debug -> Toggle Console Window!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                if (isConsoleVisible)
                {
                    HideConsoleWindow();
                    isConsoleVisible = false;
                }
            }
        }
    }
}