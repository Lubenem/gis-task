namespace Geometry;

class Rectangle : Figure
{
    private readonly float sideA;
    private readonly float sideB;

    public Rectangle(float sideA, float sideB, string color) : base(color)
    {
        this.sideA = sideA;
        this.sideB = sideB;
    }

    public override float GetArea()
    {
        float area = sideA * sideB;
        return area;
    }

    public override string GetName()
    {
        return "Rectangle";
    }
}
