using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("red", 3);
        Rectangle rectangle = new Rectangle("green", 2, 4);
        Circle circle = new Circle("blue", 2);

        List<Shape> shapes = new List<Shape>(){square, rectangle, circle};
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color of this {shape.GetName()}: {shape.GetColor()}\nArea: {shape.GetArea()} cm\n");
        }
    }
}