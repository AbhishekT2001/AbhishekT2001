// Circle.cs
class Circle : Oval
{
    public Circle(double radius) : base(2 * radius, 2 * radius)
    {
    }

    public override double Area()
    {
        return Math.PI * (MajorAxis / 2) * (MinorAxis / 2); 

    public override double Perimeter()
    {
        return 2 * Math.PI * (MajorAxis / 2);
    }


    public override string ClassName()
    {
        return "Circle";
    }
}
