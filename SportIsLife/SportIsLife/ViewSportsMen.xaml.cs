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
    /// Логика взаимодействия для ViewSportsMen.xaml
    /// </summary>
    public partial class ViewSportsMen : Window
    {
        int IDMen;
        string ConStr;
        List<string> SportsTypeName = new List<string>();
        List<int> SportsTypeInd = new List<int>();
        List<string> SportsClubsName = new List<string>();
        List<int> SportsClubsInd = new List<int>();
        public ViewSportsMen(int ID)
        {
            InitializeComponent();
            ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            IDMen = ID;

        }
        void LoadSportClubs()
        {
            SportsClubsInd.Clear();
            SportsClubsName.Clear();
            cmbSportClub.Items.Clear();
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
                    SportsClubsInd.Add(Int32.Parse(rd.GetValue(0).ToString()));
                    SportsClubsName.Add(rd.GetValue(1).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                foreach (string s in SportsClubsName)
                    cmbSportClub.Items.Add(new ComboBoxItem().Content = s);
            }
        }
        void LoadSportTypes()
        {
            SportsTypeName.Clear();
            SportsTypeInd.Clear();
            cmbSportType.Items.Clear();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * From SportType";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    SportsTypeInd.Add(Int32.Parse(rd.GetValue(0).ToString()));
                    SportsTypeName.Add(rd.GetValue(1).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                foreach (string s in SportsTypeName)
                    cmbSportType.Items.Add(new ComboBoxItem().Content = s);

            }
        }
        
        void SaveSportsMen()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into SportsMen values(@Name, @fName, @Razr, @SportClub,@SportType)";
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
                cmd.Parameters.Add("@fName", SqlDbType.VarChar).Value = txtTName.Text;
                cmd.Parameters.Add("@Razr", SqlDbType.Int).Value = Int32.Parse(cmbRaz.Text);
                cmd.Parameters.Add("@SportType", SqlDbType.Int).Value = SportsTypeInd[cmbSportType.SelectedIndex];
                cmd.Parameters.Add("@SportClub", SqlDbType.Int).Value = SportsClubsInd[cmbSportClub.SelectedIndex];
                cmd.ExecuteNonQuery();
                MessageBox.Show("Completed!");
                Close();
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
        string GetSportClub(int ID)
        {
            SqlConnection connection = null;
            string name = null;
            try
            {
                connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * From SportClub Where id="+ID.ToString();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                     name = rd.GetValue(1).ToString();
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
            return name;
        }
        string GetSportType(int ID)
        {
            SqlConnection connection = null;
            string name = null;
            try
            {
                connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * From SportType Where id=" + ID.ToString();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    name = rd.GetValue(1).ToString();
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
            return name;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSportClubs();
            LoadSportTypes();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * From SportsMen Where id ="+IDMen.ToString();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    txtName.Text = rd.GetValue(1).ToString();
                    txtTName.Text = rd.GetValue(2).ToString();
                    cmbRaz.Text = rd.GetValue(3).ToString();
                    cmbSportClub.Text = GetSportClub(Int32.Parse(rd.GetValue(4).ToString()));
                    cmbSportType.Text = GetSportType(Int32.Parse(rd.GetValue(5).ToString()));
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
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Exception ex = MainFunc.DeleteSportMen(IDMen, ConStr);
            if(ex != null)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            SaveSportsMen();
        }

        private void btnNewSportType_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNewSportClub_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
