public class Activity
{


    
    public void HoldMyHorses(string prompt, double duration = 5000, bool sameLine = true)
    {
        Console.Write(prompt);

        if (!sameLine)
        {
            Console.WriteLine();
        }
        else
        {
            Console.Write("\t");
        }

        int startPoint = Console.CursorLeft;

        while (duration >= 0)
        {
            Console.SetCursorPosition(startPoint, Console.CursorTop);

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

        Console.WriteLine();
    }
}