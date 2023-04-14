using System;

namespace ArraySwapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the array elements (comma-separated): ");
            string input = Console.ReadLine();
            
            // Split the input string into an array of integers
            int[] arr = Array.ConvertAll(input.Split(','), int.Parse);

            // Swap the first and last values, the second and penultimate values, and so on
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }

            // Output the swapped array
            Console.WriteLine("Swapped array:");
            foreach (int num in arr)
            {
                Console.Write($"{num} ");
            }

            Console.ReadLine();
        }
    }
}
