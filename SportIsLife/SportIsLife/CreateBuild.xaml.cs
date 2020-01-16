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
    /// Логика взаимодействия для CreateBuild.xaml
    /// </summary>
    public partial class CreateBuild : Window
    {
        string ConStr;
        List<int> typesInd = new List<int>();
        List<string> typesName = new List<string>();
        public CreateBuild()
        {
            InitializeComponent();
            ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        }
        void LoadDataBuildTypes()
        {
            cmbBuildType.Items.Clear();
            typesName.Clear();
            typesInd.Clear();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * From BuildAtributtes";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    typesInd.Add(Int32.Parse(rd.GetValue(0).ToString()));
                    typesName.Add(rd.GetValue(1).ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                foreach (string name in typesName)
                    cmbBuildType.Items.Add(new ComboBoxItem().Content = name);
            }
        }
        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            if (txtName.Text != "" && txtCountMens.Text!="" && cmbBuildType.SelectedIndex != -1)
            {
                try
                {
                    connection = new SqlConnection(ConStr);
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Insert into Builds values(@BuildType, @BuildName, @BuildAtr)";
                    cmd.Parameters.Add("@BuildName", SqlDbType.VarChar).Value = txtName.Text;
                    cmd.Parameters.Add("@BuildType", SqlDbType.Int).Value = typesInd[cmbBuildType.SelectedIndex];
                    cmd.Parameters.Add("@BuildAtr", SqlDbType.VarChar).Value = Int32.Parse(txtCountMens.Text);
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

        private void btnNewBuildType_Click(object sender, RoutedEventArgs e)
        {
            CreateBuildType form = new CreateBuildType();
            form.ShowDialog();
            LoadDataBuildTypes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataBuildTypes();
        }
    }
}
