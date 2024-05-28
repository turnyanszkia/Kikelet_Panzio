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
        private decimal originalPrice = 1000m;

        private BookingManager bookingManager;
        public MainWindow()
        {
            InitializeComponent();
            bookingManager = new BookingManager();
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

            if (CbxVip.IsChecked == true)
            {
                decimal discount = originalPrice * 0.03m;
                decimal discountedPrice = originalPrice - discount;

                MessageBox.Show($"Kedvezményes ár: {discountedPrice:C}", "Kedvezmény", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Eredeti ár: {originalPrice:C}", "Ár", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnFoglalas2_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse("1000", out decimal originalPrice)) 
            {
                Guest guest = new Guest
                {
                    FirstName = TbxKeresztnev.Text,
                    LastName = TbxVezeteknev.Text,
                    BirthDate = DprSzuletes.SelectedDate ?? DateTime.MinValue,
                    IsVip = CbxVip.IsChecked ?? false,
                    TotalSpent = 0 
                };

                decimal amountPaid = originalPrice;

                if (guest.IsVip)
                {
                    amountPaid -= originalPrice * 0.03m;
                }

                Booking booking = new Booking
                {
                    Guest = guest,
                    RoomNumber = 1, 
                    CheckInDate = DateTime.Now, 
                    CheckOutDate = DateTime.Now.AddDays(1), 
                    AmountPaid = amountPaid
                };

                guest.TotalSpent += amountPaid;

                //bookingManager.AddBooking(booking);

                MessageBox.Show($"Foglalás mentve! Fizetett összeg: {amountPaid:C}", "Foglalás", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnShowStatistics_Click(object sender, RoutedEventArgs e)
        {
            Statisztika statsWindow = new Statisztika(bookingManager);
            statsWindow.Show();
        }

        private void CbxSavedBookings2_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Eseménykezelő logika, ha szükséges
        }
    }
}
