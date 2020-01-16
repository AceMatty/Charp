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
    /// Логика взаимодействия для ListSportsMens.xaml
    /// </summary>
    public partial class ListSportsMens : Window
    {
        string ConStr;
        List<int> SportsMenID = new List<int>();
        public ListSportsMens()
        {
            InitializeComponent();
            ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }
        void UpdateList()
        {
            SportsMenID.Clear();
            lsMens.Items.Clear();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * From SportsMen";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ListBoxItem it = new ListBoxItem();
                    it.Content = rd.GetValue(1).ToString() + " "+ rd.GetValue(2).ToString() +"\n Разряд: "+ rd.GetValue(3).ToString();
                    it.Height = 40;
                    it.Width = 400;
                    it.BorderBrush = new SolidColorBrush(Colors.Black);
                    lsMens.Items.Add(it);
                    SportsMenID.Add(Int32.Parse(rd.GetValue(0).ToString()));
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

        private void lsMens_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewSportsMen form = new ViewSportsMen(SportsMenID[lsMens.SelectedIndex]);
            form.ShowDialog();
            UpdateList(); 
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lsMens.SelectedIndex != -1)
            {
                MainFunc.DeleteSportMen(SportsMenID[lsMens.SelectedIndex], ConStr);
                UpdateList();
            }
            else
            {
                MessageBox.Show("Выберете спортсмена!");
            }
            
        }
    }
}
