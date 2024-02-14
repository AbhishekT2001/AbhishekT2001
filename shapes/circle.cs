using System;

public class Circle : Oval
{
    public double Radius { get; set; }

    public override void CalculateArea()
    {
        Area = Math.PI * Radius * Radius;
    }

    public override void CalculatePerimeter()
    {
        Perimeter = 2 * Math.PI * Radius;
    }
    public Circle()
    {
        MajorAxis = Radius * 2;
        MinorAxis = Radius * 2;
    }
}
