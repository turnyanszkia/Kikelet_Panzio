﻿using System.Collections.Generic;
using System;
using System.Linq;

namespace Kikelet_Panzio
{
    public class BookingManager : BookingManagerBase
    {
        // A foglalások listája
        private List<Booking> bookings;

        internal int GetMostBookedRoom()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<object> GetReturningGuests()
        {
            throw new NotImplementedException();
        }

        //// Konstruktor
        public BookingManager()
        {
            bookings = new List<Booking>();
        }

        // Összes bevétel kiszámítása egy adott időszakban
        public decimal GetTotalRevenue(DateTime fromDate, DateTime toDate)
        {
            return bookings
                .Where(b => b.CheckInDate >= fromDate && b.CheckOutDate <= toDate)
                .Sum(b => b.AmountPaid);
        }

        // A legtöbbet kiadott szoba meghatározása
        public int GetMostBookedRoom2()
        {
            return bookings
                .GroupBy(b => b.RoomNumber)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }

        // Visszajáró vendégek listájának előállítása fizetett összeg szerint csökkenő sorrendben
        public List<Guest> GetReturningGuests2()
        {
            return bookings
                .GroupBy(b => b.Guest)
                .Where(g => g.Count() > 1)
                .Select(g => new
                {
                    Guest = g.Key,
                    TotalSpent = g.Sum(b => b.AmountPaid)
                })
                .OrderByDescending(g => g.TotalSpent)
                .Select(g => g.Guest)
                .ToList();
        }
    }
}