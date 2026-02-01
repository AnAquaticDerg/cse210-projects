public static class DeluxeConsole
{
    /// <summary>
    /// Writes a string to the console using a typewriter-style effect, pausing for a short duration between characters,
    /// with longer pauses applied to punctuation, and then writes a line terminator at the end.
    /// </summary>
    /// <param name="inputString">
    /// The text to be written to the console. If empty or omitted, only a line terminator is written.
    /// </param>
    /// <param name="inputSpeed">
    /// Controls the writing speed. Valid values range from 0 to 4, where lower values produce slower output
    /// and higher values produce faster output. Values outside this range are clamped to the nearest valid value.
    /// </param>
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
}

// This exists purely as a backup until I learn how to send this file to other projects.