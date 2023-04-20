public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}

public class Square : Shape
{
    private double _side;

    public Square(double side)
    {
        _side = side;
    }

    public override double CalculateArea()
    {
        return _side * _side;
    }

    public override double CalculatePerimeter()
    {
        return 4 * _side;
    }
}

public class Triangle : Shape
{
    private double _base;
    private double _height;
    private double _side1;
    private double _side2;

    public Triangle(double b, double h, double s1, double s2)
    {
        _base = b;
        _height = h;
        _side1 = s1;
        _side2 = s2;
    }

    public override double CalculateArea()
    {
        return 0.5 * _base * _height;
    }

    public override double CalculatePerimeter()
    {
        return _base + _side1 + _side2;
    }
}

public class Circle : Shape
{
    private double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * _radius;
    }
}
