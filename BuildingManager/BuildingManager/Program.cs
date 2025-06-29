using System;
using BuildingManager.Models;
using BuildingManager.Enums;
using BuildingManager.Services;
using BuildingManager.Menu;
using BuildingManager.Services.SearchHandler;

namespace BuildingManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = BuildingLog.Instance;
            var apartmentLog = ApartmentLog.Instance;
            var residentLog = ResidentLog.Instance;
            var search = new SearchHandler(log, apartmentLog, residentLog);
            var storage = new LogStorage("Entry_log", "Resident_log", "Apartment_log");
            var menu = new MenuHandler(log, search, storage, residentLog, apartmentLog);

            apartmentLog.AddEntry(new Apartment(1, 1));
            apartmentLog.AddEntry(new Apartment(2, 1));
            apartmentLog.AddEntry(new Apartment(3, 1));
            apartmentLog.AddEntry(new Apartment(1, 2));
            apartmentLog.AddEntry(new Apartment(2, 2));

            storage.SaveApartmentLog(apartmentLog);

            apartmentLog.LoadFromList(storage.LoadApartments());
            log.LoadFromList(storage.LoadEntries());
            residentLog.LoadFromList(storage.LoadResidents());

            menu.Start();

            log.AddEntry(new Entry
            {
                Date = DateTime.Now,
                Type = EntryType.Maintenance,
                Description = "Changed lightbulb in hallway",
                AddedBy = "Manager Ivanov"
            });

            log.AddEntry(new Entry
            {
                Date = DateTime.Now,
                Type = EntryType.Meeting,
                Description = "Scheduled meeting with residents",
                AddedBy = "Manager Ivanov"
            });

            foreach (var entry in log.GetAllEntries())
            {
                entry.PrintDetails();
            }

            storage.SaveLog(log);
        }
    }
}

