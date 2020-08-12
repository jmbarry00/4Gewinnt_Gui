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
    public partial class GameGUI : Form
    {
        public GameGUI()
        {
            InitializeComponent();
        }

        private void GameGUI_Load(object sender, EventArgs e)
        {
            int bottom = 30;
            for (int i = 0; i < 2; i++)
            {
                Panel panel1 = new Panel();
                this.Controls.Add(panel1);
                panel1.Left = 30;
                panel1.Width = 60;
                panel1.Height = 60;
                panel1.Top = this.ClientSize.Height - panel1.Height - bottom;
                panel1.BorderStyle = BorderStyle.FixedSingle;
                bottom += 30;
            }
            
        }
    }
}
