using System.Collections.Generic;
using System.Windows.Documents;

namespace Kikelet_Panzio
{
    public class BookingManagerBase
    {

        protected List<Booking> bookings = new List<Booking>();

        // Új foglalás hozzáadása
        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }

        public List<Booking> Bookings { get { return bookings; } }
    }
}