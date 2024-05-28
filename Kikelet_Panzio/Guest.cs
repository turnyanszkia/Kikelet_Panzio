using System;

namespace Kikelet_Panzio
{
    public class Guest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsVip { get; set; }

        public decimal TotalSpent { get; set; }

        public Guest(string firstName, string lastName, DateTime birthDate, bool isVip)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            IsVip = isVip;
            TotalSpent = 0;
        }

        public Guest() { }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override string ToString()
        {
            return $"Név: {GetFullName()}, Születési dátum: {BirthDate.ToShortDateString()}, VIP: {IsVip}, Összesen fizetett: {TotalSpent:C}";
        }
    }
}