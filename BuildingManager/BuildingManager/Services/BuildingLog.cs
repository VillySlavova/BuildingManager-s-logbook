using System.Collections.Generic;
using BuildingManager.Models;

namespace BuildingManager.Services
{
    public class BuildingLog
    {
        private static BuildingLog _instance;
        private static readonly object _lock = new();
        private List<Entry> entries;

        private BuildingLog()
        {
            entries = new List<Entry>();
        }

        public static BuildingLog Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new BuildingLog();
                }
            }
        }

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public List<Entry> GetAllEntries()
        {
            return entries;
        }
    }
}
