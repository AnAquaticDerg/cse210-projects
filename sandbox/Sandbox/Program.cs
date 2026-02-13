using System;
using System.Reflection.Metadata.Ecma335;
using static DeluxeConsole;

class Program
{
    static void Main(string[] args)
    {
        // WriteLineDeluxe("Hello Sandbox Project!",1);


    static    void DisplayProgressBar()
    {
        double _points = 850;
double _pointsToNextLevel = 1000;
        double pointsPercentage = _points / _pointsToNextLevel * 100;
        int repeats = 20;

        Console.Write("|");
        while (repeats > 0)
        {
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
        Console.Write("|");
    }

    DisplayProgressBar();
    }

}
