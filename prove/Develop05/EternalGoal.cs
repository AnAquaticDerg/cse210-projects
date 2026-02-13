using System.Text.Json.Serialization;

public class EternalGoal : Goal
{
    [JsonInclude]
    private int _timesCompleted;

    [JsonConstructor]
    public EternalGoal() {}
    public EternalGoal(string title, int pointValue) : base(title, pointValue)
    {
        _timesCompleted = 0;
        _status = $"completed {_timesCompleted} time(s)";
    }

    public override void UpdateCompletion()
    {
        _timesCompleted += 1;

        _status = $"completed {_timesCompleted} time(s)";
    }
}