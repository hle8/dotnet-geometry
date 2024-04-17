using GeometryCalc.Library.Shapes;

namespace GeometryCalc.Tests;

[TestFixture]
public class TriangleTests
{
    [TestCase(2, 3, 4, 2.905)]
    [TestCase(10, 10, 10, 43.301)]
    public void ShouldReturnArea_WhenGivenThreeSides(
        double rightSide,
        double leftSide,
        double bottomSide,
        double expected
    )
    {
        var _triangle = new Triangle(rightSide, leftSide, bottomSide);
        Assert.That(Math.Round(_triangle.CalculateArea(), 3), Is.EqualTo(expected));
    }

    [TestCase(3, 6, 7, 16)]
    [TestCase(10, 10, 10, 30)]
    public void ShouldReturnPerimeter_WhenGivenThreeSides(
        double rightSide,
        double leftSide,
        double bottomSide,
        double expected
    )
    {
        var _triangle = new Triangle(rightSide, leftSide, bottomSide);
        Assert.That(_triangle.CalculatePerimeter(), Is.EqualTo(expected));
    }
}
