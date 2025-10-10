public class Rectangle : Shape
{
    private double _length1;
    private double _width1;

    public Rectangle(string color, double length, double width) : base (color)
    {
        _length1 = length;
        _width1 = width;
    }
    public override double GetArea()
    {
        return _length1 * _width1;
    }
}