public class Circle : Shape
{
    private double _radius;
    private string _color;
    
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.Pow(_radius, 2) * 3.14;
    }
    public override string GetName()
    {
        return "circle";
    }
}