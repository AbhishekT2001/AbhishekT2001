using System;

public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public override void CalculateArea()
    {
        Area = Length * Width;
    }

    public override void CalculatePerimeter()
    {
        Perimeter = 2 * (Length + Width);
    }
}
