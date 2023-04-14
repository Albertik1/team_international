using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the size of the playing field
            const int rows = 20;
            const int columns = 40;

            // Initialize the playing field with random values
            bool[,] field = new bool[rows, columns];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    field[i, j] = random.NextDouble() < 0.5;
                }
            }

            // Loop through the generations of the game
            int generation = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Generation: {generation}");

                // Output the playing field to the console
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(field[i, j] ? "*" : " ");
                    }
                    Console.WriteLine();
                }

                // Copy the playing field to a new array for the next generation
                bool[,] newField = new bool[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        int neighbors = 0;

                        // Count the number of living neighbors for each cell
                        for (int x = i - 1; x <= i + 1; x++)
                        {
                            for (int y = j - 1; y <= j + 1; y++)
                            {
                                if (x >= 0 && x < rows && y >= 0 && y < columns && field[x, y])
                                {
                                    neighbors++;
                                }
                            }
                        }

                        // Apply the rules of the game to each cell
                        if (field[i, j])
                        {
                            neighbors--; // Subtract the cell itself from the count of neighbors
                            if (neighbors == 2 || neighbors == 3)
                            {
                                newField[i, j] = true;
                            }
                            else
                            {
                                newField[i, j] = false;
                            }
                        }
                        else
                        {
                            if (neighbors == 3)
                            {
                                newField[i, j] = true;
                            }
                            else
                            {
                                newField[i, j] = false;
                            }
                        }
                    }
                }

                // Set the playing field to the new array for the next generation
                field = newField;

                // Wait for a short period of time before displaying the next generation
                System.Threading.Thread.Sleep(100);
                generation++;
            }
        }
    }
}
