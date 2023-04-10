using System;

class Program
{
    static void Main(string[] args)
    {
        // Input coordinates of 3 points in 2-dimensional coordinate system
        Console.WriteLine("Enter coordinate x of dot A:");
        double x1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter coordinate y of dot A:");
        double y1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter coordinate x of dot B:");
        double x2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter coordinate y of dot B:");
        double y2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter coordinate x of point C:");
        double x3 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter coordinate y of point C:");
        double y3 = double.Parse(Console.ReadLine());

        // Calculate the length of sides
        double a = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        double b = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
        double c = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));

        // Round the values to 2 decimal places
        a = Math.Round(a, 2);
        b = Math.Round(b, 2);
        c = Math.Round(c, 2);

        // Output the length of sides
        Console.WriteLine("Length of side a: " + a);
        Console.WriteLine("Length of side b: " + b);
        Console.WriteLine("Length of side c: " + c);

        // Check whether it is equilateral triangle
        bool isEquilateral = (a == b) && (b == c);
        Console.WriteLine("Is it equilateral triangle? " + isEquilateral);

        // Check whether it is isosceles triangle
        bool isIsosceles = (a == b) || (b == c) || (c == a);
        Console.WriteLine("Is it isosceles triangle? " + isIsosceles);

        // Check whether it is right triangle
        bool isRight = (a * a + b * b == c * c) || (b * b + c * c == a * a) || (c * c + a * a == b * b);
        Console.WriteLine("Is it right triangle? " + isRight);

        // Calculate the perimeter of the triangle
        double perimeter = a + b + c;
        Console.WriteLine("Perimeter of triangle: " + perimeter);

        // Output even numbers from 0 to perimeter
        Console.WriteLine("Even numbers from 0 to perimeter:");
        for (int i = 0; i <= perimeter; i += 2)
        {
            Console.WriteLine(i);
        }
    }
}
