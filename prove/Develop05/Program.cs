using System;
using System.Linq.Expressions;
using System.Text.Json;
using static DeluxeConsole;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        WriteLineDeluxe("Welcome to your Eternal Quest! Get ready to start tackling more goals than ever! What is your name?");

        string usernameInput = Console.ReadLine();
        EternalQuest eternalQuest = new EternalQuest(usernameInput);

        WriteLineDeluxe($"Nice to meet you, {usernameInput}!");
        DisplaySpinner(3);

        int decision = 0;
        do
        {
            Console.Clear();
            WriteLineDeluxe("Select something to do:\n   1. See your current level\n   2. Complete a goal\n   3. Create a goal\n   4. Save your data to a file\n   5. Load your data from a file\n   6. Quit", 3);
            decision = int.Parse(Console.ReadLine());

            if (decision == 1)
            {
                eternalQuest.DisplayLevel();
            }
            else if (decision == 2)
            {
                eternalQuest.CompleteGoal();
            }
            else if (decision == 3)
            {
                eternalQuest.CreateGoal();
            }
            else if (decision == 4)
            {
                WriteLineDeluxe("What file do you want to save your data to? (exclude the file extension)");
                string filename = Console.ReadLine() + ".json";

                string jsonEternalQuestString = JsonSerializer.Serialize(eternalQuest);
                File.WriteAllText(filename, jsonEternalQuestString);

                WriteLineDeluxe($"\nData saved to \"{filename}\"");
                DisplaySpinner(3);
            }
            else if (decision == 5)
            {
                try
                {
                    WriteLineDeluxe("What file do you want to load your data from? (exclude the file extension)");
                    string filename = Console.ReadLine() + ".json";

                    string jsonEternalQuestString = File.ReadAllText(filename);
                    EternalQuest jsonEternalQuest = JsonSerializer.Deserialize<EternalQuest>(jsonEternalQuestString);
                    eternalQuest = jsonEternalQuest;

                    WriteLineDeluxe($"\nData loaded from \"{filename}\"!");
                    DisplaySpinner(3);   
                }
                catch (FileNotFoundException)
                {
                    WriteLineDeluxe("The file was not found.");
                    DisplaySpinner(3);
                }
            }
            else if (decision == 6)
            {
                WriteLineDeluxe("Have a wonderful day!");
                DisplaySpinner(3);
            }

        } while(decision != 6);
    }
}