using System;
using System.Collections.Generic;
using System.Linq;

public class Polynomial
{
    private readonly List<double> _coefficients;

    public Polynomial(params double[] coefficients)
    {
        _coefficients = coefficients.ToList();
    }

    public override string ToString()
    {
        var terms = new List<string>();
        for (int i = _coefficients.Count - 1; i >= 0; i--)
        {
            var c = _coefficients[i];
            if (c != 0)
            {
                var term = "";
                if (c > 0 && i != _coefficients.Count - 1) term += "+";
                if (c != 1 && c != -1 || i == 0) term += c.ToString();
                if (i > 0) term += "x";
                if (i > 1) term += "^" + i;
                terms.Add(term);
            }
        }
        return string.Join(" ", terms);
    }

    public static Polynomial operator +(Polynomial p1, Polynomial p2)
    {
        var maxDegree = Math.Max(p1._coefficients.Count, p2._coefficients.Count);
        var c1 = p1._coefficients.Concat(Enumerable.Repeat(0.0, maxDegree - p1._coefficients.Count));
        var c2 = p2._coefficients.Concat(Enumerable.Repeat(0.0, maxDegree - p2._coefficients.Count));
        var sum = c1.Zip(c2, (a, b) => a + b).ToArray();
        return new Polynomial(sum);
    }

    public static Polynomial operator -(Polynomial p1, Polynomial p2)
    {
        var maxDegree = Math.Max(p1._coefficients.Count, p2._coefficients.Count);
        var c1 = p1._coefficients.Concat(Enumerable.Repeat(0.0, maxDegree - p1._coefficients.Count));
        var c2 = p2._coefficients.Concat(Enumerable.Repeat(0.0, maxDegree - p2._coefficients.Count));
        var diff = c1.Zip(c2, (a, b) => a - b).ToArray();
        return new Polynomial(diff);
    }

    public static Polynomial operator *(Polynomial p1, Polynomial p2)
    {
        var resultCoeffs = new double[p1._coefficients.Count + p2._coefficients.Count - 1];
        for (int i = 0; i < p1._coefficients.Count; i++)
        {
            for (int j = 0; j < p2._coefficients.Count; j++)
            {
                resultCoeffs[i + j] += p1._coefficients[i] * p2._coefficients[j];
            }
        }
        return new Polynomial(resultCoeffs);
    }
}
var p1 = new Polynomial(1, 2, 3);
var p2 = new Polynomial(4, 5, 6, 7);
Console.WriteLine(p1); // "3x^2 + 2x + 1"
Console.WriteLine(p2); // "7x^3 + 6x^2 + 5x + 4"
Console.WriteLine(p1 + p2); // "7x^3 + 9x^2 + 7x + 5"
Console.WriteLine(p1 - p2); // "-7x^3 - 3x^2 - 3x - 3"
Console.WriteLine(p1 * p2); // "28x^5 + 38x^
