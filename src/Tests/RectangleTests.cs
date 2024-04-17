using GeometryCalc.Library.Shapes;

namespace GeometryCalc.Tests;

[TestFixture]
public class RectangleTests
{
    [TestCase(2, 3, 6)]
    [TestCase(10, 10, 100)]
    [TestCase(0, 20, 0)]
    public void ShouldReturnArea_WhenGivenLengthAndWidth(
        double length,
        double width,
        double expected
    )
    {
        var _rectangle = new Rectangle(length, width);
        Assert.That(_rectangle.CalculateArea(), Is.EqualTo(expected));
    }

    [TestCase(0, 3, 6)]
    [TestCase(1, 1, 4)]
    [TestCase(10, 10, 40)]
    public void ShouldReturnPerimeter_WhenGivenLengthAndWidth(
        double length,
        double width,
        double expected
    )
    {
        var _rectangle = new Rectangle(length, width);
        Assert.That(_rectangle.CalculatePerimeter(), Is.EqualTo(expected));
    }
}
