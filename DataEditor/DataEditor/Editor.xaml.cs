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
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace DataEditor
{
    /// <summary>
    /// Логика взаимодействия для Editor.xaml
    /// </summary>
    public class ObjectXml
    {
        public string name;
        public List<string> AtrName = new List<string>();
        public List<string> AtrHelp = new List<string>();
        public List<string> AtrValue= new List<string>();
    }
    public partial class Editor : Window
    {
        string file_path;
        List<ObjectXml> objects = new List<ObjectXml>();
        int ObjInd;
        public Editor(string path)
        {
            file_path = path;
            InitializeComponent();
        }
        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ObjInd = listBox.SelectedIndex;
            listBox2.Items.Clear();
            ObjectXml obj = objects[listBox.SelectedIndex];
            foreach(string s in obj.AtrName)
            {
                ListBoxItem item = new ListBoxItem();
                item.Height = 40;
                item.Width = 150;
                item.Content = s;
                listBox2.Items.Add(item);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(file_path);
                XmlElement root = document.DocumentElement;
                foreach(XmlElement node in root)
                {
                    ObjectXml obj = new ObjectXml();
                    if (node.Attributes.GetNamedItem("name") != null)
                    {
                        XmlNode atr = node.Attributes.GetNamedItem("name");
                        obj.name = atr.Value;
                    }
                    foreach(XmlNode child in node.ChildNodes)
                    {
                        XmlNode att = child.Attributes.GetNamedItem("help");
                        if (att != null)
                            obj.AtrHelp.Add(child.Attributes.GetNamedItem("help").Value);
                        else
                            obj.AtrHelp.Add("");
                        obj.AtrName.Add(child.Name);
                        obj.AtrValue.Add(child.InnerText);
                    }
                    objects.Add(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach(ObjectXml obj in objects)
            {
                ListBoxItem item = new ListBoxItem();
                item.Height = 40;
                item.Width = 150;
                item.Content = obj.name;
                listBox.Items.Add(item);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            objects.RemoveAt(listBox.SelectedIndex);
            listBox.Items.RemoveAt(listBox.SelectedIndex);
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            objects[listBox.SelectedIndex].AtrValue[listBox2.SelectedIndex] = txtValue.Text;
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void listBox2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtValue.Text = objects[ObjInd].AtrValue[listBox2.SelectedIndex].ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObjectXml));
            File.Delete(file_path);
            using (FileStream fs = new FileStream(file_path, FileMode.Create))
            {
                foreach(ObjectXml s in objects)
                serializer.Serialize(fs, s);
            }
            Close();
        }
    }
}
