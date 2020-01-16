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
using System.Data.SqlClient;
using System.Data;
using System.Windows.Shapes;

namespace SportIsLife
{
    /// <summary>
    /// Логика взаимодействия для CreateSportClub.xaml
    /// </summary>
    public partial class CreateSportClub : Window
    {
        string ConStr;
        public CreateSportClub()
        {
            InitializeComponent();
            ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            if (txtName.Text != "")
            {
                try
                {
                    connection = new SqlConnection(ConStr);
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into SportClub values(@Name)";
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
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
           
        }
    }
}
