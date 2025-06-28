namespace BuildingManager.Models
{
    public class Resident
    {

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public bool IsOwner { get; private set; }
        public int ApartmentNumber { get; private set; }

        public Resident(string name, string phoneNumber, bool isOwner)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name can not be empty");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number can not be empty");

            Name = name;
            PhoneNumber = phoneNumber;
            IsOwner = isOwner;
        }

        internal void AssignApartmentNumber(int apartmentNumber)
        {
            if (apartmentNumber <= 0)
                throw new ArgumentException("Invalid Apartment number");

            ApartmentNumber = apartmentNumber;
        }

        public override string ToString()
        {
            string role = IsOwner ? "Owner" : "Tenant";
            return $"{Name} ({role}), phone number: {PhoneNumber}";
        }
    }
}




