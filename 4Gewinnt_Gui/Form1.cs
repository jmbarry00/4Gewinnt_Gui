using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt_Gui
{
    public partial class Form1 : Form
    {
        int anzZeilen = 0;
        int anzSpalten = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameGUI gui = new GameGUI();
            anzZeilen = Convert.ToInt32(tbZeilen.Text);
            anzSpalten = Convert.ToInt32(tbSpalten.Text);
            gui.Show();
            this.Hide();
        }
    }
}
