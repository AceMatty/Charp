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
    /// Логика взаимодействия для CreateBuildType.xaml
    /// </summary>
    public partial class CreateBuildType : Window
    {
        string ConStr;
        public CreateBuildType()
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
                    cmd.CommandText = "Insert into BuildAtributtes values(@Name)";
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
