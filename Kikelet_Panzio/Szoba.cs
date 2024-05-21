using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kikelet_Panzio
{
    internal class Szoba
    {
        int szobaszam;
        int ferohely;
        int ar;

        public Szoba(int szobaszam, int ferohely, int ar)
        {
            Szobaszam = szobaszam;
            Ferohely = ferohely;
            Ar = ar;
        }

        public int Szobaszam { get => szobaszam; set => szobaszam = value; }
        public int Ferohely { get => ferohely; set => ferohely = value; }
        public int Ar { get => ar; set => ar = value; }

        public Szoba(string sor)
        {
            string[] bontas = sor.Split(';');
            Szobaszam = int.Parse(bontas[0]);
            Ferohely = int.Parse(bontas[1]);
            Ar = int.Parse(bontas[2]);
        }
    }
}
