using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        // First Step
        Console.WriteLine("What is your first name?");
        string first_name = Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string last_name = Console.ReadLine();
        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}.");

        // Second Step
        Console.WriteLine("What is your grade percentage?");
        string gradeString = Console.ReadLine();
        int grade = int.Parse(gradeString);

        string letterGrade = "";
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"{letterGrade}");

        if (letterGrade == "A" || letterGrade == "B" || letterGrade == "C")
        {
            Console.WriteLine("Congradulations! You passed!");
        }
        else
        {
            Console.WriteLine("You didn't pass, but if you work hard, you'll pass next time!");
        }
    }
}