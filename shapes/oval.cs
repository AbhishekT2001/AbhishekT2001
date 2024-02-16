// Oval.cs
using System;

class Oval : Shape
{
    public double MajorAxis { get; }
    public double MinorAxis { get; }

    public Oval(double majorAxis, double minorAxis) : base(majorAxis, minorAxis)
    {
        MajorAxis = majorAxis;
        MinorAxis = minorAxis;
    }

    public override double Area()
    {
        return Math.PI * MajorAxis * MinorAxis;
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Math.Sqrt((MajorAxis * MajorAxis + MinorAxis * MinorAxis) / 2);
    }

    public override string ClassName()
    {
        return "Oval";
    }
}
