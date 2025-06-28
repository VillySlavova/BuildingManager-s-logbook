using System;

namespace BuildingManager.Models
{
    public class Apartment
    {
        public int Number { get; private set; }
        public int Floor { get; private set; }
        
        private readonly List<Resident> _residents = new();
        public IReadOnlyList<Resident> Residents => _residents.AsReadOnly();

        public Resident? Owner => _residents.FirstOrDefault(r => r.IsOwner);

        public Apartment(int number, int floor)
        {
            if (number <= 0) throw new ArgumentException("Invalid number of apartment");
            if (floor < 0) throw new ArgumentException("Invalid floor number. It has to be positive");

            Number = number;
            Floor = floor;

        }

        public void AddResident(Resident resident)
        {
            if (resident == null)
                throw new ArgumentNullException(nameof(resident));

            if (resident.IsOwner && Owner != null)
                throw new InvalidOperationException("Apartment has already owner.");

            if (!_residents.Contains(resident))
            {
                resident.AssignApartmentNumber(Number);
                //resident.ApartmentNumber = Number;
                _residents.Add(resident);
            }
        }


        public void RemoveResident(string name)
        {
            var resident = _residents.FirstOrDefault(r => r.Name == name);
            if (resident != null)
            {
                _residents.Remove(resident);
            }
        }

        public IEnumerable<Resident> GetOwners() => _residents.Where(r => r.IsOwner);

        public IEnumerable<Resident> GetTenants() => _residents.Where(r => !r.IsOwner);


        public void PrintResidents()
        {
            Console.WriteLine($"Apartment {Number} - Floor {Floor}");
            foreach (var r in _residents)
            {
                Console.WriteLine($"  - {r}");
            }
        }

        public override string ToString()
        {
            return $"Apartment {Number}, Floor: {Floor}, Residents: {_residents.Count}";
        }
    }
}