using System.Text.Json;
using BuildingManager.Models;
using BuildingManager.Services;

public class LogStorage
{
    private string filePath;
    public LogStorage(string filePath)
    {
        this.filePath = filePath;
    }
    public void SaveLog(BuildingLog log)
    {
        var entries = log.GetAllEntries();
        var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
    public List<Entry> LoadEntries()
    {
        if (!File.Exists(filePath))
        {
            return new List<Entry>();
        }
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
    }
}