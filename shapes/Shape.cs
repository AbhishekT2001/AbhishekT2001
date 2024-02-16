// Shape.cs
using System;

abstract class Shape
{
    private static int serialCounter = 1;

    public int SerialNumber { get; }
    public double XAxis { get; }
    public double YAxis { get; }

    public Shape(double xAxis, double yAxis)
    {
        SerialNumber = serialCounter++;
        XAxis = xAxis;
        YAxis = yAxis;
    }

    public abstract double Area();
    public abstract double Perimeter();
    public abstract string ClassName();
}
