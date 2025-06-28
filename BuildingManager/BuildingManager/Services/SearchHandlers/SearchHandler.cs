using BuildingManager.Enums;
using BuildingManager.Models;

namespace BuildingManager.Services.SearchHandler
{
    public class SearchHandler
    {
        private BuildingLog log;
        private ApartmentLog apartmentLog;
        private ResidentLog residentLog;
        public BuildingLog Log
        {
            get
            {
                return log;
            }
            private set
            {
                log = value;
            }
        }
        public ApartmentLog ApartmentLog
        {
            get
            {
                return apartmentLog;
            }
            private set
            {
                apartmentLog = value;
            }
        }
        public ResidentLog ResidentLog
        {
            get
            {
                return residentLog;
            }
            private set
            {
                residentLog = value;
            }
        }
        public SearchHandler(BuildingLog log, ApartmentLog apartmentLog, ResidentLog residentLog)
        {
            this.Log = log;
            this.ApartmentLog = apartmentLog;
            this.ResidentLog = residentLog;
        }
        public List<Entry> SearchEntry(
            string? date = null,
            string? type = null,
            string? addedBy = null,
            bool print = false,
            NameMatchType matchType = NameMatchType.Contains)
        {
            var found = log.GetAllEntries()
                .Where(e =>
                    (date == null || e.Date.ToString() == date.ToString()) &&
                    (type == null || e.Type.ToString() == type.ToString()) &&
                    (addedBy == null || IsNameMatch(e.AddedBy, addedBy, matchType))
                ).ToList();
            if (print)
            {
                foreach (Entry entry in found)
                {
                    entry.PrintDetails();
                }
            }
            return found;
        }
        private bool IsNameMatch(string fullName, string searchTerm, NameMatchType matchType)
        {
            return matchType switch
            {
                NameMatchType.Exact => fullName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase),
                NameMatchType.Contains => fullName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase),
                NameMatchType.StartsWith => fullName.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase),
                _ => false
            };
        }
        public List<Apartment> SearchApartment(
            int number = 0,
            int floor = 0,
            bool print = false)
        {
            var found = apartmentLog.GetAllEntries()
                .Where(e =>
                    (number == 0 || e.Number == number) &&
                    (floor == 0 || e.Floor == floor)
                ).ToList();
            if (print)
            {
                foreach (Apartment apartment in found)
                {
                    apartment.ToString();
                }
            }
            return found;
        }
        public List<Resident> SearchResident(
            string? phoneNumber = null,
            string? name = null,
            int apartmentNumber = 0,
            NameMatchType matchType = NameMatchType.Contains,
            bool print = false)
        {
            var found = residentLog.GetAllEntries()
                .Where(e =>
                    (phoneNumber == null || e.PhoneNumber == phoneNumber) &&
                    (name == null || IsNameMatch(e.Name, name, matchType)) && 
                    (apartmentNumber == 0 || e.ApartmentNumber == apartmentNumber)
                ).ToList();
            if (print)
            {
                foreach (Resident resident in found)
                {
                    resident.ToString();
                }
            }
            return found;
        }
    }
}