using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using static DeluxeConsole;

public class EternalQuest
{
    [JsonInclude]
    private double _points;
    [JsonInclude]
    private int _level;
    [JsonInclude]
    private double _pointsToNextLevel;
    [JsonInclude]
    private List<string> _levelingMessages;
    [JsonInclude]
    private string _username;
    [JsonInclude]
    private List<Goal> _goals;

    public EternalQuest() {}
    public EternalQuest(string username)
    {
        _points = 0;
        _pointsToNextLevel = 500;
        _level = 1;
        _levelingMessages = new List<string>
        {
            "Goal Novice",
            "Goal Apprentice",
            "Goal Keeper",
            "Diligent One",
            "Task Crusher",
            "Ambition Seeker",
            "Promise Keeper",
            "Point Gatherer",
            "Goal Master",
            "Cool Person"
        };
        _username = username;
        _goals = new List<Goal>();
    }

    public void DisplayLevel()
    {
        int milestoneInterval = 5;
        int milestoneTitleIndex = _level / milestoneInterval;
        if (milestoneTitleIndex > _levelingMessages.Count() - 1)
        {
            milestoneTitleIndex = _levelingMessages.Count();
        }
        string milestoneTitle = _levelingMessages[milestoneTitleIndex];

        Console.Clear();
        WriteLineDeluxe($"{_username}: Level {_level} {milestoneTitle}.\nProgress to next level:");
        DisplayProgressBar();
        DisplaySpinner(5);
    }
    private void DisplayProgressBar()
    {
        double pointsPercentage = _points / _pointsToNextLevel * 100;
        int repeats = 20;

        Console.Write("|");
        while (repeats > 0)
        {
            Thread.Sleep(100);
            if ((int)pointsPercentage / 5 > 0)
            {
                Console.Write("=");
            }
            else
            {
                Console.Write(" ");
            }
            pointsPercentage -= 5;
            repeats--;
        }
        Console.Write("|\n");
    }
    public void CompleteGoal()
    {
        if (_goals.Count() == 0)
        {
            WriteLineDeluxe("There aren't any goals to complete.");
            DisplaySpinner(3);
            return;
        }
        int selectedGoalIndex = -2;
        while (selectedGoalIndex < 0 || selectedGoalIndex > _goals.Count() - 1)
        {
            Console.Clear();
            WriteLineDeluxe("Select a goal to complete from the list below:");
            ListGoals();
            selectedGoalIndex = int.Parse(Console.ReadLine()) - 1;
        }

        Goal selectedGoal = _goals[selectedGoalIndex];
        
        if (selectedGoal.GetCompletionStatus() != "completed")
        {
            _points += selectedGoal.GetPointValue();
        }
        UpdateLevel();
        
        selectedGoal.UpdateCompletion();

        WriteLineDeluxe($"\"{selectedGoal.GetGoalName()}\" has now been {selectedGoal.GetCompletionStatus()}.");
        DisplaySpinner();
    }
    private void ListGoals()
    {
        int i = 1;
        foreach (Goal goal in _goals)
        {
            WriteLineDeluxe($"{i}. {goal.GetGoalName()}: {goal.GetCompletionStatus()}");
            i++;
        }
    }
    private void UpdateLevel()
    {
        while (_points >= _pointsToNextLevel)
        {
            double startingAmount = _points - _pointsToNextLevel;
            _points = startingAmount;
            _pointsToNextLevel = _pointsToNextLevel + _level * 50;

            _level++;
            WriteLineDeluxe($"You leveled up! You are now level {_level}! Great job!");
        }
    }
    public void CreateGoal()
    {
        Console.Clear();
        WriteLineDeluxe("To create your goal, first give your goal a title.");
        string goalTitle = Console.ReadLine();

        WriteLineDeluxe("Next, assign the goal a point value, which is awarded when you complete your goal.");
        int pointValue = int.Parse(Console.ReadLine());

        WriteLineDeluxe("Now you must decide what type of goal to make:\n1. Simple goal (1 time completion)\n2. Eternal goal (never finished)\n3. Checklist Goal (completed a set amount of times)");
        int chosenGoalType = int.Parse(Console.ReadLine());

        if (chosenGoalType == 1)
        {
            SimpleGoal newSimpleGoal = new SimpleGoal(goalTitle, pointValue);
            _goals.Add(newSimpleGoal);

            WriteLineDeluxe($"The simple goal \"{newSimpleGoal.GetGoalName()}\" has been created.");
        }
        else if (chosenGoalType == 2)
        {
            EternalGoal newEternalGoal = new EternalGoal(goalTitle, pointValue);
            _goals.Add(newEternalGoal);

            WriteLineDeluxe($"The eternal goal \"{newEternalGoal.GetGoalName()}\" has been created.");
        }
        else if (chosenGoalType == 3)
        {
            WriteLineDeluxe("How many times do you plan on completing this goal?");
            int denominator = int.Parse(Console.ReadLine());

            ChecklistGoal newChecklistGoal = new ChecklistGoal(goalTitle, pointValue, denominator);
            _goals.Add(newChecklistGoal);

            WriteLineDeluxe($"The eternal goal \"{newChecklistGoal.GetGoalName()}\" has been created.");
        }

        DisplaySpinner();
    }
}