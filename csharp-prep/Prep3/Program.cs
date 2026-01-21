using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(2, 3);

        f1.SetTop(2);
        Console.WriteLine(f1.GetFractionString());

        Console.WriteLine(f2.GetFractionString());

        Console.WriteLine(f3.GetDecimalValue());

        Random random = new Random();

        int count = 1;
        while (count <= 20)
        {
            int randomNumerator = random.Next(20);
            int randomDenominator = random.Next(20);

            Fraction f4 = new Fraction(randomNumerator, randomDenominator);

            Console.WriteLine(f4.GetFractionString());
            Console.WriteLine(f4.GetDecimalValue());

            count += 1;
        }
    }
}