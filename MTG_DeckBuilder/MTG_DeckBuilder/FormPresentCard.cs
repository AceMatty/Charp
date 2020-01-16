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
    public partial class FormPresentCard : Form
    {
        string name;
        public FormPresentCard(string Name)
        {
            name = Name;
            InitializeComponent();
        }

        private void FormPresentCard_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "Res\\dbc\\" + name +"\\"+name+".png";
            labelName.Text = File.ReadAllText("Res\\dbc\\" + name + "\\" +name + "1.data");
            labelMana.Text = "Манакост: " + File.ReadAllText("Res\\dbc\\" + name + "\\" + name + "2.data");
            labelHealthAndAt.Text = "Урон/Здоровье: " + File.ReadAllText("Res\\dbc\\" + name + "\\" + name + "3.data") + "/"+ File.ReadAllText("Res\\dbc\\" + name + "\\" + name + "4.data");
            labelEdition.Text = "Издание: " + File.ReadAllText("Res\\dbc\\" + name + "\\" + name + "5.data");
            labelType.Text = "Тип: " + File.ReadAllText("Res\\dbc\\" + name + "\\" + name + "7.data");
            labelRare.Text = "Редкость: " + File.ReadAllText("Res\\dbc\\" + name + "\\" + name + "6.data");
        }
    }
}
