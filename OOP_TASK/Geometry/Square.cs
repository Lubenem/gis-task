namespace Geometry;

class Square : Rectangle
{
    public Square(float side, string color) : base(side, side, color)
    {
    }

    public override string GetName()
    {
        return "Square";
    }
}
