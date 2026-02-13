using System.Text.Json.Serialization;
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(SimpleGoal), "simple")]
[JsonDerivedType(typeof(EternalGoal), "eternal")]
[JsonDerivedType(typeof(ChecklistGoal), "checklist")]

public abstract class Goal
{
    [JsonInclude]
    private string _title;
    [JsonInclude]
    protected int _pointValue;
    [JsonInclude]
    protected string _status;

    public Goal() {}
    public Goal(string title, int pointValue)
    {
        _title = title;
        _pointValue = pointValue;
        _status = "";
    }

    public string GetGoalName()
    {
        return _title;
    }
    public int GetPointValue()
    {
        return _pointValue;
    }
    public string GetCompletionStatus()
    {
        return _status;
    }

    public abstract void UpdateCompletion();
}