using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Kikelet_Panzio
{
    /// <summary>
    /// Interaction logic for Foglalas.xaml
    /// </summary>
    public partial class Foglalas : Window
    {
        public Foglalas()
        {
            InitializeComponent();
            var ferohelyek = new HashSet<int>();
            foreach (var szoba in szobak)
            {
                ferohelyek.Add(szoba.Ferohely);
            }
            CbxFerohey.ItemsSource = ferohelyek;
        }
        private List<Szoba> szobak = new List<Szoba>
        {
            new Szoba(1, 2, 6000),
            new Szoba(2, 2, 6000),
            new Szoba(3, 3, 9000),
            new Szoba(4, 3, 9000),
            new Szoba(5, 4, 12000),
            new Szoba(6, 4, 12000)
        };
        private void CbxFerohey_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CbxFerohey.SelectedItem != null)
            {
                int kivalasztottFerohely = (int)CbxFerohey.SelectedItem;

                // Megfelelő szoba keresése
                foreach (var szoba in szobak)
                {
                    if (szoba.Ferohely == kivalasztottFerohely)
                    {
                        TbkAr.Text = $"Szoba szám: {szoba.Szobaszam}, Ár: {szoba.Ar} Ft";
                        break;
                    }
                }
            }
        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e)
        {
            if (CbxFerohey.SelectedItem != null)
            {
                int kivalasztottFerohely = (int)CbxFerohey.SelectedItem;
                Szoba kivalasztottSzoba = null;

                foreach (var szoba in szobak)
                {
                    if (szoba.Ferohely == kivalasztottFerohely)
                    {
                        kivalasztottSzoba = szoba;
                        break;
                    }
                }

                if (kivalasztottSzoba != null)
                {
                    string filePath = "adatokMentese.txt";
                    using (StreamWriter writer = new StreamWriter(filePath, append: true))
                    {
                        writer.WriteLine($"Szoba szám: {kivalasztottSzoba.Szobaszam}, Férőhely: {kivalasztottSzoba.Ferohely}, Ár: {kivalasztottSzoba.Ar} Ft");
                    }

                    MessageBox.Show("Foglalás sikeres!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Nincs megfelelő szoba kiválasztva.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Kérjük, válasszon férőhelyet.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnMegsem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
