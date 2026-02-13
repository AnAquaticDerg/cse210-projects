using System.Text.Json.Serialization;

public class SimpleGoal : Goal
{
    [JsonConstructor]
    public SimpleGoal() {}
    public SimpleGoal(string title, int pointValue) : base(title, pointValue)
    {
        _status = "not completed";
    }

    public override void UpdateCompletion()
    {
        _status = "completed";
    }
}