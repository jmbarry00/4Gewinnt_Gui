﻿using _4Gewinnt_Gui.Controller;
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
        GameController Ctr;

        public Form1()
        {
            InitializeComponent();
        }

        private void GameClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Anzahl Zeilen und Spalten dem Programm übergeben
        private void button1_Click(object sender, EventArgs e)
        {   
            try
            {
                anzZeilen = Convert.ToInt32(tbZeilen.Text);
                anzSpalten = Convert.ToInt32(tbSpalten.Text);
                if (anzZeilen >= 5 && anzSpalten >= 5)
                {
                    Ctr = new GameController(anzZeilen, anzSpalten);
                    this.Hide();
                } else
                {
                    tbSpalten.Text = "";
                    tbZeilen.Text = "";
                    MessageBox.Show("Wähle mindestens 5 Zeilen und Spalten!");
                }
            } 
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
        }

    }
}
