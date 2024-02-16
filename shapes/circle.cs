// Circle.cs
class Circle : Oval
{
    public Circle(double radius) : base(2 * radius, 2 * radius)
    {
    }

    public override string ClassName()
    {
        return "Circle";
    }
}
