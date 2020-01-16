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
using System.IO;



namespace DataEditor
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
        List<string> files = new List<string>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            try
            {
                DirectoryInfo dir = new DirectoryInfo(@"data/");
                FileInfo[] inf = dir.GetFiles("*.xml");
                foreach (FileInfo f in inf)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Height = 40;
                    item.Width = 400;
                    item.Content = f.Name;
                    files.Add(f.FullName);
                    listBox.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Editor form = new Editor(files[listBox.SelectedIndex]);
            form.ShowDialog();
        }
    }
}
