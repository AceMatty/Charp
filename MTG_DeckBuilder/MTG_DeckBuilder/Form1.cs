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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string[] Cards;
        void LoadCard()
        {
            StreamReader sr = new StreamReader("Res\\index_cours.txt");
            int count = Int32.Parse(sr.ReadLine());
            sr.Close();
            label1.Text = count.ToString();
            Cards = new string[count];
            StreamReader read = new StreamReader("Res\\index_f.txt");
            for (int i = 0; i < count; i++){
                Cards[i] = read.ReadLine();
                listBox1.Items.Add(Cards[i]);
            }
            read.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardAdder ca = new CardAdder();
            ca.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            LoadCard();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormPresentCard f = new FormPresentCard(listBox1.Items[listBox1.SelectedIndex].ToString());
            f.ShowDialog();
        }
    }
}
