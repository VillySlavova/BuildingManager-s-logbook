using BuildingManager.Models;

namespace BuildingManager.Services
{
    public class ApartmentLog
    {
        private static ApartmentLog _instance;
        private static readonly object _lock = new();
        private List<Apartment> apartments;

        private ApartmentLog()
        {
            apartments = new List<Apartment>();
        }

        public static ApartmentLog Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new ApartmentLog();
                }
            }
        }

        public void AddEntry(Apartment apartment)
        {
            apartments.Add(apartment);
        }

        public List<Apartment> GetAllEntries()
        {
            return apartments;
        }
        public void LoadFromList(List<Apartment> loadedApartments)
        {
            apartments = new List<Apartment>(loadedApartments);
        }
    }
}