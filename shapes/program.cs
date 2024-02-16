// Program.cs
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter dimensions for Rectangle (length width):");
        double rectLength = double.Parse(Console.ReadLine());
        double rectWidth = double.Parse(Console.ReadLine());
        Rectangle rectangle = new Rectangle(rectLength, rectWidth);

        Console.WriteLine("\nEnter dimensions for Oval (majorAxis minorAxis):");
        double ovalMajorAxis = double.Parse(Console.ReadLine());
        double ovalMinorAxis = double.Parse(Console.ReadLine());
        Oval oval = new Oval(ovalMajorAxis, ovalMinorAxis);

        Console.WriteLine("\nEnter radius for Circle:");
        double circleRadius = double.Parse(Console.ReadLine());
        Circle circle = new Circle(circleRadius);

        DisplayShapeDetails(rectangle);
        DisplayShapeDetails(oval);
        DisplayShapeDetails(circle);
    }

    static void DisplayShapeDetails(Shape shape)
    {
        Console.WriteLine($"Shape Type: {shape.ClassName()}");
        Console.WriteLine($"Serial Number: {shape.SerialNumber}");
        Console.WriteLine($"X-Axis: {shape.XAxis}, Y-Axis: {shape.YAxis}");
        Console.WriteLine($"Area: {shape.Area():F2}, Perimeter: {shape.Perimeter():F2}");
        Console.WriteLine();
    }
}
