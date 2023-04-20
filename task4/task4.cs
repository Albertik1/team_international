using System;

class Program {
    static void Main(string[] args) {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i <= n; i++) {
            Console.Write(Fibonacci(i) + " ");
        }
    }

    static int Fibonacci(int n) {
        if (n == 0) {
            return 0;
        } else if (n == 1) {
            return 1;
        } else {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
