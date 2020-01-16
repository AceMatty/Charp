using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MTG_DeckBuilder
{
    public partial class CardAdder : Form
    {
        public CardAdder()
        {
            InitializeComponent();
        }
        public string[] ImagePath = new string[7];
        public string PathImg;

        public void LoadImages()
        {
            for (int i = 0; i < ImagePath.Length; i++)
            {
                ImagePath[i] = "Res//images//" + i.ToString() + ".png";
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxEditImage_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxEditImage.ImageLocation = ImagePath[comboBoxEdition.SelectedIndex];
        }

        private void CardAdder_Load(object sender, EventArgs e)
        {

            LoadImages();

        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                PathImg = openFileDialog1.FileName;
                pictureBox1.ImageLocation = PathImg;

            }
        }



        private void buttonCreateCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.Text != null)
                {


                    Directory.CreateDirectory("Res\\dbc\\" + textBoxName.Text + "\\");
                    File.WriteAllText("Res\\dbc\\" + textBoxName.Text + "\\" + textBoxName.Text + "1.data", textBoxName.Text);
                    File.WriteAllText("Res\\dbc\\" + textBoxName.Text + "\\" + textBoxName.Text + "2.data", numericUpDownMana.Value.ToString());
                    File.WriteAllText("Res\\dbc\\" + textBoxName.Text + "\\" + textBoxName.Text + "3.data", numericUpDownAttack.Value.ToString());
                    File.WriteAllText("Res\\dbc\\" + textBoxName.Text + "\\" + textBoxName.Text + "4.data", numericUpDownHealth.Value.ToString());
                    File.WriteAllText("Res\\dbc\\" + textBoxName.Text + "\\" + textBoxName.Text + "5.data", comboBoxEdition.Text);
                    File.WriteAllText("Res\\dbc\\" + textBoxName.Text + "\\" + textBoxName.Text + "6.data", comboBoxRare.Text);
                    File.WriteAllText("Res\\dbc\\" + textBoxName.Text + "\\" + textBoxName.Text + "7.data", comboBoxType.Text);
                    if (PathImg != null)
                    {
                        File.Move(PathImg, "Res\\dbc\\" + textBoxName.Text + "\\" + textBoxName.Text + ".png");
                    }

                    StreamWriter sw = new StreamWriter("Res\\index_f.txt", true);
                    sw.WriteLine(textBoxName.Text);
                    sw.Close();
                    StreamReader sr = new StreamReader("Res\\index_cours.txt");
                    int a = Int32.Parse(sr.ReadLine());
                    sr.Close();
                    StreamWriter sw2 = new StreamWriter("Res\\index_cours.txt",false);
                    a++;
                    sw2.WriteLine(a);
                    sw2.Close();
                }
                else
                {
                    MessageBox.Show("Проверте данные!");
                }

                MessageBox.Show("Успешно!!");
                Close();
            }
            catch
            {
                MessageBox.Show("Проверте данные!");
            }
          
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 2)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                numericUpDownAttack.Value = 0;
                numericUpDownHealth.Value = 0;
            }
        }

    }
}


