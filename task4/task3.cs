using System;

public class Program {
    public static void Main() {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        int a = 0, b = 1, c = 0;
        while (c < n) {
            Console.Write("{0} ", c);
            a = b;
            b = c;
            c = a + b;
        }
    }
}
