using GeometryCalc.Library.Shapes.Interfaces;

namespace GeometryCalc.Library.Shapes;

public class Square : IShape
{
    private readonly double length;

    public Square(double length)
    {
        this.length = length;
    }

    public double CalculateArea()
    {
        return length * length;
    }

    public double CalculatePerimeter()
    {
        return length * 4;
    }
}
