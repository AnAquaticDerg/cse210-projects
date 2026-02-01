using static DeluxeConsole;
using System.ComponentModel;

public class Activity
{
    private string _activityType;
    private string _description;
    private DateTime _duration;
    private int _durationInt;

    public Activity(string activityName, string description)
    {
        _activityType = activityName;
        _description = description;
        _duration = DateTime.Now;
    }
    
    private void SetEndTime()
    {
        WriteLineDeluxe($"\nHow long do you want to perform this activity? (Respond in seconds)");

        string durationString = Console.ReadLine();
        _durationInt = int.Parse(durationString);
        _duration = DateTime.Now.AddSeconds(_durationInt);
    }
    protected DateTime GetEndTime()
    {
        return _duration;
    }
    protected int GetDuration()
    {
        return _durationInt;
    }
    protected void GreetUser()
    {
        Console.Clear();
        WriteLineDeluxe($"\nThis is the {_activityType} Activity.\n{_description}");
        DisplaySpinner(3);

        SetEndTime();

        WaitWithPrompt("\nPrepare to begin...");

    }
    protected void BidFarewell()
    {
        WriteLineDeluxe($"\nThis concludes your {_activityType} Activity, which you spent {GetDuration()} seconds doing.\nHopefully as you've taken time to meditate, you will find yourself more at peace. You've done a wonderful job.");
        DisplaySpinner(7);


    }
    protected void WaitWithPrompt(string prompt, float durationBase = 5)
    {
        float duration = durationBase * 1000;

        Console.Write($"{prompt}\t");

        int startingPoint = Console.CursorLeft;

        while (duration >= 0)
        {
            Console.SetCursorPosition(startingPoint, Console.CursorTop);

            if (duration % 1000 != 0)
            {
                Console.Write($"{duration/1000}");
            }
            else
            {
                Console.Write($"{duration/1000}.0");
            }
            Thread.Sleep(100);

            duration -= 100;
        }
        Console.SetCursorPosition(startingPoint, Console.CursorTop);
        Console.Write("          ");

        WriteLineDeluxe();
    }
    protected void DisplaySpinner(float durationBase = 5)
    {
        WriteLineDeluxe();

        float duration = durationBase * 1000;
        int i = 0;

        while (duration >= 0)
        {
            List<string> animationStrings = new List<string>{"|", "/", "-", "\\", "|", "/", "-", "\\"};

            Console.Write(animationStrings[i]);
            Thread.Sleep(200);
            duration -= 200;
            Console.Write("\b \b");
            i++;

            if (i >= animationStrings.Count())
            {
                i = 0;
            }
        }
    }

}