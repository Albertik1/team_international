using System;

namespace MatrixModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and fill the original matrix
            int[,] matrix = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            // Get the number of rows and columns in the matrix
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            // Declare the result matrix with the same size as the original matrix
            int[,] result = new int[rows, columns];

            // Loop through the original matrix and copy its values to the result matrix,
            // inserting a value of zero to the left of the main diagonal and a value of one to the right
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j < i)
                    {
                        // Insert a value of zero to the left of the main diagonal
                        result[i, j] = 0;
                    }
                    else if (j > i)
                    {
                        // Insert a value of one to the right of the main diagonal
                        result[i, j] = 1;
                    }
                    else
                    {
                        // Copy the value from the original matrix
                        result[i, j] = matrix[i, j];
                    }
                }
            }

            // Output the result matrix to the console
            Console.WriteLine("Result matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
