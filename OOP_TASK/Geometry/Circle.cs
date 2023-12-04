namespace Geometry;

class Circle : Figure
{
    private readonly float radius;

    public Circle(float radius, string color) : base(color)
    {
        this.radius = radius;
    }

    public override float GetArea()
    {
        float pi = MathF.Round(MathF.PI, 2);
        float area = pi  * MathF.Pow(radius, 2);
        return area;
    }

    public override string GetName()
    {
        return "Circle";
    }
}
