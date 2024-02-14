using System;

public class Oval : Shape
{
    public double MajorAxis { get; set; }
    public double MinorAxis { get; set; }

    public override void CalculateArea()
    {
        Area = Math.PI * MajorAxis * MinorAxis;
    }

    public override void CalculatePerimeter()
    {
        double a = MajorAxis / 2;
        double b = MinorAxis / 2;
        Perimeter = 2 * Math.PI * Math.Sqrt((a * a + b * b) / 2);
    }
}
