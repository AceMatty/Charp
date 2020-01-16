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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace SportIsLife
{
    /// <summary>
    /// Логика взаимодействия для ListSportClubs.xaml
    /// </summary>
    public partial class ListSportClubs : Window
    {
        string ConStr;
        List<int> SportClubsID = new List<int>();
        public ListSportClubs()
        {
            InitializeComponent();
            ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        void UpdateList()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * From SportClub";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListBoxItem it = new ListBoxItem();
                    it.Content = "Название: "+rd.GetValue(1).ToString()+" \n Кол-во участников "+MainFunc.CountSportClub(Int32.Parse(rd.GetValue(0).ToString()),ConStr);
                    it.Height = 40;
                    it.BorderBrush = new SolidColorBrush(Colors.Black);
                    it.Width = 400;
                    lsMens.Items.Add(it);
                    SportClubsID.Add(Int32.Parse(rd.GetValue(0).ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void lsMens_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lsMens_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lsMens.SelectedIndex != -1)
            {
                MainFunc.DeleteSportClub(SportClubsID[lsMens.SelectedIndex], ConStr);
                UpdateList();
            }
            else
            {
                MessageBox.Show("Выберете спортсмена!");
            }
        }
    }
}
