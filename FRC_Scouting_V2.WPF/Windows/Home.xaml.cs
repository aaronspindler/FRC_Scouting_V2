using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FRC_Scouting_V2.WPF
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void eventSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (eventSelector.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("0");
                    break;
                case 1:
                    MessageBox.Show("1");
                    break;
            }
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ProgramInformationMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Source = new Uri("/Pages/ProgramInformation.xaml", UriKind.Relative);
        }
    }
}
