using System;

namespace BuildingManager.Models
{
    public class UninhabitedApartment : Apartment
    {
        public DateTime LastOccupiedDate { get; private set; }

        public UninhabitedApartment(int number, int floor, DateTime lastOccupiedDate)
            : base(number, floor)
        {
            LastOccupiedDate = lastOccupiedDate;
        }

        public override string ToString()
        {
            return $"Apartment {Number} (uninhabited until {LastOccupiedDate:dd.MM.yyyy})";
        }
    }
}