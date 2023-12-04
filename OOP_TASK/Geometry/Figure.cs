namespace Geometry;

public abstract class Figure
{
    protected readonly string color;

    public Figure(string color)
    {
        this.color = color;
    }

    public string GetAreaInfo()
    {
        string name = GetName();
        float area = GetArea();
        return $"Area of {color} {name} is {area}";
    }

    public abstract float GetArea();
    public abstract string GetName();
}
