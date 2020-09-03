using _4Gewinnt.Model;
using _4Gewinnt_Gui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt_Gui.Controller
{
    public class GameController
    {
        GameGUI gui;
        public Spiel spiel;
        public Spielfeld spielfeld;
        public Spieler spieler;
        int[,] feld;
        public int anzZeilen;
        public int anzSpalten;
        bool spieler1Won;
        bool spieler2Won;
        bool unentschieden;
        bool player1;
        bool player2;
        bool spalteVoll;

        public GameController(int Zeilen, int Spalten)
        {
            anzZeilen = Zeilen;
            anzSpalten = Spalten;
            this.gui = new GameGUI(this);
            gui.Show();            
        }

        public void AnzZeilenSpalten()
        {
            spiel = new Spiel(anzZeilen, anzSpalten);
            spiel.spielStarten();
            spieler = spiel.spieler;
            spielfeld = spiel.spielfeld;
            feld = spielfeld.feld;
            player1 = spieler.player1;
            player2 = spieler.player2;
        }


        private void ControllerGetModelData()
        {
            feld = spielfeld.feld;
            spieler1Won = spielfeld.spieler1Won;
            spieler2Won = spielfeld.spieler2Won;
            unentschieden = spielfeld.unentschieden;
            player1 = spieler.player1;
            player2 = spieler.player2;
            spalteVoll = spielfeld.spalteVoll;
        }

        public void updateModelData()
        {
            spielfeld.feld = feld;
            spielfeld.spieler1Won = spieler1Won;
            spielfeld.spieler2Won = spieler2Won;
            spielfeld.unentschieden = unentschieden;
            spieler.player1 = player1;
            spieler.player2 = player2;
            spielfeld.spalteVoll = spalteVoll;
        }

        public int[,] getFeld()
        {
            return feld;
        }

        public bool getPlayer1()
        {
            return player1;
        }

        public bool getPlayer2()
        {
            return player2;
        }

        public bool getSpalteVoll()
        {
            return spalteVoll;
        }

        public bool getUnentschieden()
        {
            return unentschieden;
        }

        public bool getSpieler1Won()
        {
            return spieler1Won;
        }

        public bool getSpieler2Won()
        {
            return spieler2Won;
        }



        public void setViewData(int[,] feld, bool spieler1Won, bool spieler2Won, bool unentschieden, bool player1, bool player2, bool spalteVoll)
        {
            this.feld = feld;
            this.spieler1Won = spieler1Won;
            this.spieler2Won = spieler2Won;
            this.unentschieden = unentschieden;
            this.player1 = player1;
            this.player2 = player2;
            this.spalteVoll = spalteVoll;
        }




        public void Spielen(int gewSpalte)
        {
            spielfeld.FeldBesetzen(gewSpalte, spieler);
            ControllerGetModelData();
        }


    }
}
