namespace Kikelet_Panzio
{
    public class BookingManagerBase
    {

        // Új foglalás hozzáadása
        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }
    }
}