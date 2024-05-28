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
using System.Linq;

namespace Kikelet_Panzio
{
    /// <summary>
    /// Interaction logic for Statisztika.xaml
    /// </summary>
    public partial class Statisztika : Window
    {
        private BookingManager bookingManager;
        public Statisztika(BookingManager bookingManager)
        {
            InitializeComponent();
            this.bookingManager = bookingManager;
            LoadStatistics();
        }
        private void LoadStatistics()
        {
            // Legtöbbet kiadott szoba
            int mostBookedRoom = bookingManager.GetMostBookedRoom();
            TbkMostBookedRoom.Text = mostBookedRoom != 0 ? mostBookedRoom.ToString() : "Nincs adat";

            // Visszajáró vendégek
            var returningGuests = bookingManager.GetReturningGuests();
            LbxReturningGuests.Items.Clear();
            foreach (var guest in returningGuests)
            {
                LbxReturningGuests.Items.Add($"{guest.FirstName} {guest.LastName} - {guest.TotalSpent:C}");
            }
        }

        private void BtnCalculateRevenue_Click(object sender, RoutedEventArgs e)
        {
            if (DpkFromDate.SelectedDate.HasValue && DpkToDate.SelectedDate.HasValue)
            {
                DateTime fromDate = DpkFromDate.SelectedDate.Value;
                DateTime toDate = DpkToDate.SelectedDate.Value;

                decimal totalRevenue = bookingManager.GetTotalRevenue(fromDate, toDate);
                TbkTotalRevenue.Text = totalRevenue.ToString("C");
            }
            else
            {
                MessageBox.Show("Kérjük, válasszon ki egy érvényes dátumtartományt!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
