using GeometryCalc.Library.Shapes.Interfaces;

namespace GeometryCalc.Library.Shapes;

public class Triangle : IShape
{
    private readonly double rightSide;
    private readonly double leftSide;
    private readonly double bottomSide;

    public Triangle(double rightSide, double leftSide, double bottomSide)
    {
        this.rightSide = rightSide;
        this.leftSide = leftSide;
        this.bottomSide = bottomSide;
    }

    public double CalculateArea()
    {
        var s = CalculatePerimeter() / 2;
        // Heron’s Formula
        return Math.Sqrt(s * (s - rightSide) * (s - leftSide) * (s - bottomSide));
    }

    public double CalculatePerimeter()
    {
        return rightSide + leftSide + bottomSide;
    }
}
