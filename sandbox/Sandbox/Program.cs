using System;

class Program
{
    static void Main(string[] args)
    {
        
        string longWord = "Exceptional job you did today! I appreciate you for who you are, Tristan!";
        foreach (char ch in longWord)
        {
            if (char.IsPunctuation(ch))
            {
                Console.Write(ch);
                Thread.Sleep(150);
            }
            else if (!char.IsWhiteSpace(ch))
            {
                Console.Write(ch);
                Thread.Sleep(25); 
            }
            else
            {
                Console.Write(ch);
            }
        }
        Console.WriteLine();
        

    }

    
}