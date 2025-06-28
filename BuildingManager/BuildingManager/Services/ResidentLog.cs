using BuildingManager.Models;

namespace BuildingManager.Services
{
    public class ResidentLog
    {
        private static ResidentLog _instance;
        private static readonly object _lock = new();
        private List<Resident> residents;

        private ResidentLog()
        {
            residents = new List<Resident>();
        }

        public static ResidentLog Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new ResidentLog();
                }
            }
        }

        public void AddEntry(Resident Resident)
        {
            residents.Add(Resident);
        }

        public List<Resident> GetAllEntries()
        {
            return residents;
        }
        public void LoadFromList(List<Resident> loadedresidents)
        {
            residents = new List<Resident>(loadedresidents);
        }
    }
}