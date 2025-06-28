using System;

namespace BuildingManager.Models
{
    public class SmartApartment : Apartment
    {
        public double CurrentTemperature { get; private set; }
        public bool IsDoorLocked { get; private set; }
        public bool SmokeDetected { get; private set; }

        public SmartApartment(int number, int floor)
            : base(number, floor)
        {
            CurrentTemperature = 22.0;
            IsDoorLocked = true;
            SmokeDetected = false;
        }

        public void UpdateTemperature(double temperature)
        {
            if (temperature < -10 || temperature > 40)
                throw new ArgumentException("Unrealistic temperature");

            CurrentTemperature = temperature;
        }

        public void LockDoor() => IsDoorLocked = true;

        public void UnlockDoor() => IsDoorLocked = false;

        public void ReportSmoke(bool detected) => SmokeDetected = detected;

        public override string ToString()
        {
            return base.ToString() +
                   $", Temp: {CurrentTemperature}°C, Door Locked: {IsDoorLocked}, Smoke: {(SmokeDetected ? "Yes" : "No")}" ;
        }
    }
}
