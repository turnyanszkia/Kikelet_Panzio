using System;

namespace Kikelet_Panzio
{
    public class Booking
    {

        public Guest Guest { get; set; }

        public int RoomNumber { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public decimal AmountPaid { get; set; }

        public Booking(Guest guest, int roomNumber, DateTime checkInDate, DateTime checkOutDate, decimal amountPaid)
        {
            Guest = guest;
            RoomNumber = roomNumber;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            AmountPaid = amountPaid;
        }

        public Booking() { }

        public int GetDuration()
        {
            return (CheckOutDate - CheckInDate).Days;
        }

        public override string ToString()
        {
            return $"Vendég: {Guest.FirstName} {Guest.LastName}, Szoba: {RoomNumber}, " +
                   $"Bejelentkezés: {CheckInDate.ToShortDateString()}, " +
                   $"Kijelentkezés: {CheckOutDate.ToShortDateString()}, " +
                   $"Fizetett összeg: {AmountPaid:C}";
        }
    }
}