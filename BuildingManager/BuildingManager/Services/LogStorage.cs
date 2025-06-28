using System.Text.Json;
using BuildingManager.Models;
namespace BuildingManager.Services
{
    public class LogStorage
    {
        private string entryFile;
        private string apartmentFile;
        private string residentFile;
        public LogStorage(string entryFile, string residentFile, string apartmentFile)
        {
            this.entryFile = entryFile;
            this.residentFile = residentFile;
            this.apartmentFile = apartmentFile;
        }
        public void SaveLog(BuildingLog log)
        {
            var entries = log.GetAllEntries();
            var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(entryFile, json);
        }
        public List<Entry> LoadEntries()
        {
            if (!File.Exists(entryFile))
            {
                return new List<Entry>();
            }
            var json = File.ReadAllText(entryFile);
            return JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
        }
        public void SaveApartmentLog(ApartmentLog apartmentLog)
        {
            var apartments = apartmentLog.GetAllEntries();
            var json = JsonSerializer.Serialize(apartments, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(apartmentFile, json);
        }
        public List<Apartment> LoadApartments ()
        {
            if (!File.Exists(apartmentFile))
            {
                return new List<Apartment>();
            }
            var json = File.ReadAllText(apartmentFile);
            return JsonSerializer.Deserialize<List<Apartment>>(json) ?? new List<Apartment>();
        }public void SaveResidentsLog(ResidentLog residentLog)
        {
            var residents = residentLog.GetAllEntries();
            var json = JsonSerializer.Serialize(residents, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(residentFile, json);
        }
        public List<Resident> LoadResidents()
        {
            if (!File.Exists(residentFile))
            {
                return new List<Resident>();
            }
            var json = File.ReadAllText(residentFile);
            return JsonSerializer.Deserialize<List<Resident>>(json) ?? new List<Resident>();
        }
    }
}


