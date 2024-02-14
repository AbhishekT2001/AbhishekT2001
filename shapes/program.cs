using System;

public class Program
{
    public static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle();
        GetRectangleDetails(rectangle);
        rectangle.CalculateArea();
        rectangle.CalculatePerimeter();
        rectangle.SerialNumber = Guid.NewGuid();
        rectangle.PrintDetails();

        Oval oval = new Oval();
        GetOvalDetails(oval);
        oval.CalculateArea();
        oval.CalculatePerimeter();
        oval.SerialNumber = Guid.NewGuid();
        oval.PrintDetails();

        Circle circle = new Circle();
        GetCircleDetails(circle);
        circle.CalculateArea();
        circle.CalculatePerimeter();
        circle.SerialNumber = Guid.NewGuid();
        circle.PrintDetails();

        Console.ReadLine();
    }

    private static void GetRectangleDetails(Rectangle rectangle)
    {
        Console.Write("Please enter the rectangle length (in cm): ");
        rectangle.Length = double.Parse(Console.ReadLine());

        Console.Write("Please enter the rectangle width (in cm): ");
        rectangle.Width = double.Parse(Console.ReadLine());

        Console.WriteLine();
    }

    private static void GetOvalDetails(Oval oval)
    {
        Console.Write("Please enter the oval major axis (in cm): ");
        oval.MajorAxis = double.Parse(Console.ReadLine());

        Console.Write("Please enter the oval minor axis (in cm): ");
        oval.MinorAxis = double.Parse(Console.ReadLine());

        Console.WriteLine();
    }

    private static void GetCircleDetails(Circle circle)
    {
        Console.Write("Please enter the circle radius (in cm): ");
        circle.Radius = double.Parse(Console.ReadLine());

        Console.WriteLine();
    }
}
