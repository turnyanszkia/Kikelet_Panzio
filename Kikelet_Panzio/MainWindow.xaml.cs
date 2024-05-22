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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Kikelet_Panzio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadSavedBookings();
        }

        private void BtnFoglalas_Click(object sender, RoutedEventArgs e)
        {
            string text1 = TbxKeresztnev.Text;
            string text2 = TbxVezeteknev.Text;
            string date = DprSzuletes.SelectedDate.HasValue ? DprSzuletes.SelectedDate.Value.ToString("yyyy-MM-dd") : "Nincs dátum kiválasztva";

            string filePath = "adatokMentes.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Vezetéknév:{text1}");
                writer.WriteLine($"Keresztnév:{text2}");
                writer.WriteLine($"Születési dátum:{date}");
            }

            Foglalas foglaloAblak = new Foglalas();
            foglaloAblak.Show();
        }
        private void LoadSavedBookings()
        {
            string filePath = "adatokMentese.txt";
            if (File.Exists(filePath))
            {
                var savedBookings = File.ReadAllLines(filePath);
                CbxSavedBookings.ItemsSource = savedBookings;
            }
        }
        private void CbxSavedBookings_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CbxSavedBookings.SelectedItem != null)
            {
                string selectedBooking = CbxSavedBookings.SelectedItem.ToString();
                MessageBox.Show(selectedBooking, "Mentett Foglalás", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
