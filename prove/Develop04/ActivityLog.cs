using System.Text.Json;
using System.Text.Json.Serialization;
using static DeluxeConsole;

public class ActivityLog
{
    [JsonInclude]
    private Dictionary<string, int> _activityLog;

    public void CreateNewLog()
    {
        _activityLog = new Dictionary<string, int>{{"breathing",0},{"reflecting",0},{"listing",0}};
    }
    public void DisplayLog()
    {
        Console.Clear();
        WriteLineDeluxe("How many times you have done each activity:");
        Thread.Sleep(500);

        foreach (KeyValuePair<string,int> keyValuePair in _activityLog)
        {
            WriteLineDeluxe($"Times completed the {keyValuePair.Key} activity: {keyValuePair.Value} times");
            Thread.Sleep(500);
        }

        WriteLineDeluxe("\nPress enter to go back.");
        Console.ReadLine();
    }
    public void LogActivity(string type)
    {
        int timesCompleted = _activityLog[type];
        timesCompleted += 1;

        _activityLog[type] = timesCompleted;
        string jsonLogString = JsonSerializer.Serialize(_activityLog);
        File.WriteAllText("activity_log.json", jsonLogString);        
    }
    public void LoadLog()
    {
        var jsonLogDict = File.ReadAllText("activity_log.json");
        Dictionary<string,int> loadedLogDict = JsonSerializer.Deserialize<Dictionary<string,int>>(jsonLogDict);

        _activityLog = loadedLogDict;
    }
}