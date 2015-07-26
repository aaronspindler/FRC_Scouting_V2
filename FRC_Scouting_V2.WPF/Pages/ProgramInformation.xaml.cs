using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FRC_Scouting_V2.WPF.Pages
{
    /// <summary>
    /// Interaction logic for ProgramInformation.xaml
    /// </summary>
    public partial class ProgramInformation : Page
    {
        public ProgramInformation()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new System.Uri("Pages/FRC_Logo.xaml", UriKind.Relative));
        }
    }
}
