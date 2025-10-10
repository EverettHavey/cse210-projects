public class Square : Shape
{
    private double _side1;

    public Square(string color, double side) : base (color)
    {
        _side1 = side;
    }

    public override double GetArea()
    {
        return _side1 * _side1;
    }
}