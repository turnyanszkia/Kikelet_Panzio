using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows;
using System.Xml.Linq;

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

        public override string ToString()
        {
            return $"Szoba szám: {Szobaszam}, Férőhely: {Ferohely}, Ár: {Ar} Ft";
        }
    }
}