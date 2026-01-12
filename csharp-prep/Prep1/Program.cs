using System;
using System.Net;
using System.Runtime.CompilerServices;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string numberString = Console.ReadLine();
        int number = int.Parse(numberString);
        return number;
    }
    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year that your were born: ");
        string birthYearString = Console.ReadLine();
        birthYear = int.Parse(birthYearString);
    }
    static int SquareNumber(int number)
    {
        int sqauredNumber = number ^ 2;
        return sqauredNumber;
    }
    static void DisplayResult(string name, int sqauredNumber, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {sqauredNumber}");
        Console.WriteLine($"{name}, you will turn {2026 - birthYear} this year.");
    }
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

    // Third Step
    string response = "";
    do
    {
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 100);
        int guess = -1;
        int guessCount = 0;
        do
        {
            Console.WriteLine("What is the number?");
            string guessString = Console.ReadLine();
            guess = int.Parse(guessString);
            if (guess > magic_number)
                {
                    Console.WriteLine("Lower");
                }
            else if (guess == magic_number)
                {
                    Console.WriteLine("You got it!");
                }
            else
                {
                    Console.WriteLine("Higher");
                }
        
        guessCount += 1;
        } while (!(guess == magic_number));
        Console.WriteLine($"Guesses: {guessCount}");
        Console.WriteLine("");
        Console.WriteLine("Play again?");
        response = Console.ReadLine();
        Console.WriteLine("");
    } while (response == "yes");
    
    // Fourth Step
    int userInput = -1;
    int largest = -9 ^ 99;
    int smallest = 9 ^ 99;
    int totalNumbers = -1;
    int total = 0;
    

    List<int> numbers = new List<int>();

    Console.WriteLine("Enter a list of numbers, type 0 when finished.");
    do
        {
            Console.Write("Enter number: ");
            string userInputString = Console.ReadLine();
            userInput = int.Parse(userInputString);

            numbers.Add(userInput);
            
        } while (userInput != 0);

        foreach (int number in numbers)
        {
            if (largest < number)
            {
                largest = number;
            }
            if (number >= 0 && number < smallest)
            {
                smallest = number;
            }
            totalNumbers += 1;
            total += number;    
        }

        int average = total / totalNumbers;

        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");

        // Fifth Step
        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        PromptUserBirthYear(out int birthYear);
        int squaredNumber = SquareNumber(favoriteNumber);
        DisplayResult(name, squaredNumber, birthYear);
    }
}