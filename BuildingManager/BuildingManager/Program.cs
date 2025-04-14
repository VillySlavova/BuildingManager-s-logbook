using System;
using BuildingManager.Models;
using BuildingManager.Enums;
using BuildingManager.Services;

namespace BuildingManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = BuildingLog.Instance;

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
        }
    }
}

