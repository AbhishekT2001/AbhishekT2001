// Rectangle.cs
using System;

class Rectangle : Shape
{
    public double Length { get; }
    public double Width { get; }

    public Rectangle(double length, double width) : base(length, width)
    {
        Length = length;
        Width = width;
    }

    public override double Area()
    {
        return Length * Width;
    }

    public override double Perimeter()
    {
        return 2 * (Length + Width);
    }

    public override string ClassName()
    {
        return "Rectangle";
    }
}
