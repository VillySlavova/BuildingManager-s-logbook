using System;
using BuildingManager.Enums;

namespace BuildingManager.Models
{
    public class Entry
    {
        public DateTime Date { get; set; }
        public EntryType Type { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"{Date.ToShortDateString()} - {Type}: {Description} (Added by: {AddedBy})");
        }
    }
}
