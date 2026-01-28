using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        MathAssignment mathAssignment = new MathAssignment("Tristan", "Decimals", "Section 5", "1-5, 10-23");
        Console.WriteLine($"{mathAssignment.GetHomeworkList()}\n");

        WritingAssignment writingAssignment = new WritingAssignment("Tristan", "English wiritng skilsksj", "Coolio Toolio");
        Console.WriteLine(writingAssignment.GetWritingAssignment());
    }
}