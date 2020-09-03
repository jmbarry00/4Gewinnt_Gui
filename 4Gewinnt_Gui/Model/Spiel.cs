using _4Gewinnt_Gui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt.Model
{
    public class Spiel
    {
        public Spieler spieler;
        public Spielfeld spielfeld;
        int Y;
        int X;

        public Spiel(int y, int x)
        {
            Y = y;
            X = x;
            spieler = new Spieler();
        }

        //Beim Start fängt Spieler 1 an und ein Feld wird erstellt
        public void spielStarten()
        {
            spieler.player1 = true;
            spielfeld = new Spielfeld(Y, X);
        }
    }
}

