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

namespace SportIsLife
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNewSportsMen_Click(object sender, RoutedEventArgs e)
        {
            CreateSportmen form = new CreateSportmen();
            form.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateSportClub form = new CreateSportClub();
            form.ShowDialog();
        }

        private void btnNewSportType_Click(object sender, RoutedEventArgs e)
        {
            CreateSportType form = new CreateSportType();
            form.ShowDialog();
        }

        private void btnNewBuild_Click(object sender, RoutedEventArgs e)
        {
            CreateBuild form = new CreateBuild();
            form.ShowDialog();
        }

        private void btnListSM_Click(object sender, RoutedEventArgs e)
        {
            ListSportsMens form = new ListSportsMens();
            form.ShowDialog();
        }

        private void btnListBuilds_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnListSC_Click(object sender, RoutedEventArgs e)
        {
            ListSportClubs form = new ListSportClubs();
            form.ShowDialog();
        }
    }
}
