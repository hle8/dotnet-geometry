using GeometryCalc.Library.Shapes;

namespace GeometryCalc.Tests;

[TestFixture]
public class SquareTests
{
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(3, 9)]
    [TestCase(10, 100)]
    public void ShouldReturnArea_WhenGivenLength(double length, double expected)
    {
        var _square = new Square(length);
        Assert.That(_square.CalculateArea(), Is.EqualTo(expected));
    }

    [TestCase(10, 40)]
    [TestCase(25, 100)]
    [TestCase(30, 120)]
    public void ShouldReturnPerimeter_WhenGivenLength(double length, double expected)
    {
        var _square = new Square(length);
        Assert.That(_square.CalculatePerimeter(), Is.EqualTo(expected));
    }
}
