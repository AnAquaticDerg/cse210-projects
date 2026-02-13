using System.Text.Json.Serialization;

public class ChecklistGoal : Goal
{
    [JsonInclude]
    private int _numerator;
    [JsonInclude]
    private int _denomiator;

    [JsonConstructor]
    public ChecklistGoal() {}
    public ChecklistGoal(string title, int pointValue, int denominator) : base(title, pointValue)
    {
        _numerator = 0;
        _denomiator = denominator;
        _status = $"completed {_numerator}/{denominator} time(s)";
    }

    public override void UpdateCompletion()
    {
        _numerator += 1;

        _status = $"completed {_numerator}/{_denomiator} time(s)";

        if (_numerator == _denomiator)
        {
            _pointValue = _pointValue * _denomiator;
        }
    }
}