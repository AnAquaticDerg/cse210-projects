public static class DeluxeConsole
{
    /// <summary>
    /// Writes a string to the console using a typewriter-style effect, pausing for a short duration between characters,
    /// with longer pauses applied to punctuation, and then writes a line terminator at the end.
    /// </summary>
    public static void WriteLineDeluxe(string inputString="", int inputSpeed=2)
    {
        if (inputSpeed > 4)
        {
            inputSpeed = 4;
        }
        else if (inputSpeed < 0)
        {
            inputSpeed = 0;
        }
        
        int speedA = 100;
        int speedB = 20;
        
        if (inputSpeed == 0)
        {
            speedA = 250;
            speedB = 50;
        }
        else if (inputSpeed == 1)
        {
            speedA = 150;
            speedB = 30;
        }
        else if (inputSpeed == 3)
        {
            speedA = 50;
            speedB = 10;
        }
        else if (inputSpeed == 4)
        {
            speedA = 25;
            speedB = 5;
        }

        foreach (char ch in inputString)
        {
            if (char.IsPunctuation(ch))
            {
                Console.Write(ch);
                Thread.Sleep(speedA);
            }
            else if (!char.IsWhiteSpace(ch))
            {
                Console.Write(ch);
                Thread.Sleep(speedB); 
            }
            else
            {
                Console.Write(ch);
            }
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Displays a small text spinner for a short duration to indicate the program is still running even if 
    /// waiting, waiting for a default of 5 seconds.
    /// </summary>
    public static void DisplaySpinner(float durationBase = 5)
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


// This exists purely as a backup until I learn how to send this file to other projects.