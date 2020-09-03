using _4Gewinnt_Gui.Controller;
using _4Gewinnt_Gui.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt_Gui
{
    public partial class GameGUI : Form
    {
        int Y;
        int X;
        GameController Ctr;
        Spielfeld spielfeld;
        Spieler spieler;
        bool player1;
        bool player2;
        int[,] feld;
        Panel[,] panel;
        Button[] button;
        Label[,] lb;

        int gewSpalte;
        //string neustart;

        bool spieler1Won;
        bool spieler2Won;
        bool unentschieden;
        bool outOfBounds;
        bool spalteVoll;

        public GameGUI(GameController ctr)
        {
            InitializeComponent();
            this.Ctr = ctr;
            Ctr.AnzZeilenSpalten();
            Y = Ctr.anzZeilen;
            X = Ctr.anzSpalten;
            spieler = Ctr.spieler;
            spielfeld = Ctr.spielfeld;
            feld = Ctr.getFeld();
        }

        public void Playing()
        {
            getControllerData();
            Game();
        }

        private void getControllerData()
        {
            feld = Ctr.getFeld();
            spieler1Won = Ctr.getSpieler1Won();
            spieler2Won = Ctr.getSpieler2Won();
            unentschieden = Ctr.getUnentschieden();
            player1 = Ctr.getPlayer1();
            player2 = Ctr.getPlayer2();
            outOfBounds = Ctr.getOutOfBounds();
            spalteVoll = Ctr.getSpalteVoll();
        }

        private void GameGUI_Load(object sender, EventArgs e)
        {
            panel = new Panel[Y,X];
            button = new Button[X];
            
            int bottom = 30;
            int panelHeight = 60;
            int panelWidth = 60;
            int panelLeft = 30;
            int panelId = 0;
            this.Height = Y * panelHeight + 200;
            this.Width = X * panelWidth + 100;
            int s;
            int z;

            for (s = 0; s < X; s++)
            {
                z = 0;
                panel[z,s] = new Panel();
                button[s] = new Button();
                this.Controls.Add(button[s]);
                button[s].Left = panelLeft;
                button[s].Width = panelWidth;
                button[s].Text = "V";
                button[s].Name = Convert.ToString(s);
                button[s].Top = 100;
                button[s].Click += new EventHandler(ButtonClick);

                for (z = 0; z < Y; z++)
                {
                    panel[z,s] = new Panel();
                    
                    //panel[z,s].Name = "panel" + panelId;
                    this.Controls.Add(panel[z, s]);             
                    panel[z, s].Left = panelLeft;
                    panel[z, s].Width = panelWidth;
                    panel[z, s].Height = panelHeight;
                    panel[z, s].Top = this.ClientSize.Height - panel[z, s].Height - bottom;
                    panel[z, s].BorderStyle = BorderStyle.FixedSingle;
                    bottom += 60;
                    panelId++;
                }
                panelLeft += panelWidth;
                bottom = 30;
            }
            //panel0.BackColor = Color.Red;
            
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            //To Do - Click Event
            Button btn = sender as Button;
            //MessageBox.Show(btn.Name + ", " + "Button Clicked");
            gewSpalte = Convert.ToInt32(btn.Name);

            Playing();

        }

        private void Spielsteine()
        {
            lb = new Label[Y, X];

            for (int s = 0; s < X; s++)
            {
                for (int z = 0; z < Y; z++)
                {
                    lb[z, s] = new Label();
                    panel[z, s].Controls.Add(lb[z, s]);
                    lb[z, s].Text = Convert.ToString(feld[z, s]);
                }
            }
        }

        private void Game()
        {
            if (player1 == true)
            {
                label1.Text = "Spieler 1: wähle eine Spalte!";
            } else
            {
                label1.Text = "Spieler 2: wähle eine Spalte!";
            }
                
            Ctr.Spielen(gewSpalte);
            getControllerData();
            Ctr.setViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            Ctr.updateModelData();
            Spielsteine();
            
        }
    }
}
