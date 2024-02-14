using System;

public abstract class Shape
{
    public double Area { get; set; }
    public double Perimeter { get; set; }
    public Guid SerialNumber { get; set; }

    public abstract void CalculateArea();
    public abstract void CalculatePerimeter();

    public void PrintDetails()
    {
        Console.WriteLine("Serial Number: " + SerialNumber);
        Console.WriteLine("Area: " + Area);
        Console.WriteLine("Perimeter: " + Perimeter);
        Console.WriteLine();
    }
}
