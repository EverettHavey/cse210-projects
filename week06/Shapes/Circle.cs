public class Circle : Shape
{
    private double _radiaus;

    public Circle(string color, double radiaus) : base (color)
    {
        _radiaus = radiaus;
    }

    public override double GetArea()
    {
        return _radiaus * _radiaus * Math.PI;
    }
}