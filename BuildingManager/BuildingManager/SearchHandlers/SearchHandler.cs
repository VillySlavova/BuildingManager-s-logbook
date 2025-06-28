using BuildingManager.Enums;
using BuildingManager.Models;
using BuildingManager.Services;

public class SearchHandler
{
    private BuildingLog log;
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
    public SearchHandler(BuildingLog log)
    {
        this.Log = log;
    }
    public List<Entry> Search(
        DateTime? date = null,
        EntryType? type = null,
        string? addedBy = null,
        bool print = true,
        NameMatchType matchType = NameMatchType.Contains)
    {
        var found = log.GetAllEntries()
            .Where(e =>
                (date == null || e.Date == date) &&
                (type == null || e.Type == type) &&
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
}