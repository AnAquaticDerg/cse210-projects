using System;
using static DeluxeConsole;

class Program
{
    static void Main(string[] args)
    {
        List<string> listingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        List<string> startingPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        List<string> endingPrompts = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity(startingPrompts, endingPrompts);
        ListingActivity listingActivity = new ListingActivity(listingPrompts);

        ActivityLog activityLog = new ActivityLog();
        try
        {
            activityLog.LoadLog();
        }
        catch (FileNotFoundException)
        {
            activityLog.CreateNewLog();
        }

        int input = -1;
        do
        {
            Console.Clear();
            WriteLineDeluxe("What would you like to do:\n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. View logs\n  5. Quit",4);
            string inputString = Console.ReadLine();
            try
            {
                input = int.Parse(inputString);
            }
            catch (System.FormatException)
            {
                input = -1;
            }

            if (input == 1)
            {
                breathingActivity.Breathe();
                activityLog.LogActivity("breathing");
            }
            else if (input == 2)
            {
                reflectionActivity.Reflect();
                activityLog.LogActivity("reflecting");
            }
            else if (input == 3)
            {
                listingActivity.ListThings();
                activityLog.LogActivity("listing");
            }
            else if (input == 4)
            {
                activityLog.DisplayLog();
            }
            else if (input == 5)
            {
                WriteLineDeluxe("Have a wonderful day!");
            }
        } while (input != 5);
    }
}