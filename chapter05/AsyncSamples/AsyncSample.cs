using AsyncSamples;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

public class AsyncSample
{
    public async Task<List<string>> GetDataAsync(string filePath)
    {
        using var file = File.OpenText(filePath);
        var data = await file.ReadToEndAsync();
        return data.Split(new[] { Environment.NewLine },
            StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public async Task<List<string>> GetOnlineDataAsync(string url)
    {
        var httpClient = new HttpClient();
        var data = await httpClient.GetStringAsync(url);
        return data.Split(new[] { Environment.NewLine },
            StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public async Task<List<JournalEntry>> DeserializeJournalDataAsync(List<string> journalData)
    {
        return await Task.Run(() => DeserializeEntries(journalData));
    }

    private List<JournalEntry> DeserializeEntries(List<string> journalData)
    {
        var deserializedEntries = new List<JournalEntry>();
        var serializer = new XmlSerializer(typeof(JournalEntry));
        foreach (var xmlEntry in journalData)
        {
            if (xmlEntry == null) continue;
            using var reader = new StringReader(xmlEntry);
            var entry = (JournalEntry)serializer.Deserialize(reader)!;
            if (entry == null) continue;
            deserializedEntries.Add(entry);
        }
        return deserializedEntries;
    }

    public List<JournalEntry> DeserialzeJsonEntries(List<string> journalData)
    {
        var deserializedEntries = new List<JournalEntry>();
        foreach (var jsonEntry in journalData)
        {
            if (string.IsNullOrWhiteSpace(jsonEntry)) continue;
            deserializedEntries.Add(JsonSerializer.Deserialize<JournalEntry>(jsonEntry)!);
        }
        return deserializedEntries;
    }

    public async Task<List<JournalEntry>> DeserializeJsonEntriesAsync(List<string> journalData)
    {
        var deserializedEntries = new List<JournalEntry>();
        foreach (var jsonEntry in journalData)
        {
            if (string.IsNullOrWhiteSpace(jsonEntry)) continue;
            using var stream = new MemoryStream(Encoding.Unicode.GetBytes(jsonEntry));
            deserializedEntries.Add((await JsonSerializer.DeserializeAsync<JournalEntry>(stream))!);
        }
        return deserializedEntries;
    }

    public async Task<List<JournalEntry>> GetJournalEntriesAsync(List<string> journalData)
    {
        var journalTasks = journalData.Select(entry => DeserializeJsonEntryAsync(entry));
        return (await Task.WhenAll(journalTasks)).ToList();
    }

    private async Task<JournalEntry> DeserializeJsonEntryAsync(string jsonEntry)
    {
        if (string.IsNullOrWhiteSpace(jsonEntry)) return new JournalEntry();
        using var stream = new MemoryStream(Encoding.Unicode.GetBytes(jsonEntry));
        return (await JsonSerializer.DeserializeAsync<JournalEntry>(stream))!;
    }
}