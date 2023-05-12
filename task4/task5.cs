using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Polynomial
{
    private readonly List<double> _coefficients;

    public Polynomial(params double[] coefficients)
    {
        _coefficients = coefficients.ToList();
    }

    public override string ToString()
    {
        var terms = new StringBuilder();
        for (int i = _coefficients.Count - 1; i >= 0; i--)
        {
            var c = _coefficients[i];
            if (c != 0)
            {
                if (c > 0 && i != _coefficients.Count - 1) terms.Append("+");
                if (c != 1 && c != -1 || i == 0) terms.Append(c.ToString());
                if (i > 0) terms.Append("x");
                if (i > 1) terms.Append("^" + i);
            }
        }
        return terms.ToString();
    }

    private static double[] AddOrSubtractCoefficients(List<double> c1, List<double> c2, bool add)
    {
        var maxDegree = Math.Max(c1.Count, c2.Count);
        var coeffs1 = c1.Concat(Enumerable.Repeat(0.0, maxDegree - c1.Count)).ToArray();
        var coeffs2 = c2.Concat(Enumerable.Repeat(0.0, maxDegree - c2.Count)).ToArray();
        var resultCoeffs = new double[maxDegree];
        for (int i = 0; i < maxDegree; i++)
        {
            resultCoeffs[i] = add ? coeffs1[i] + coeffs2[i] : coeffs1[i] - coeffs2[i];
        }
        return resultCoeffs;
    }

    public static Polynomial operator +(Polynomial p1, Polynomial p2)
    {
        var sumCoeffs = AddOrSubtractCoefficients(p1._coefficients, p2._coefficients, true);
        return new Polynomial(sumCoeffs);
    }

    public static Polynomial operator -(Polynomial p1, Polynomial p2)
    {
        var diffCoeffs = AddOrSubtractCoefficients(p1._coefficients, p2._coefficients, false);
        return new Polynomial(diffCoeffs);
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
Console.WriteLine(p1 * p2); // "28x^5 + 38x^4 + 32x^3 + 31x^
