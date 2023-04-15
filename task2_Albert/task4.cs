using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the size of the field
            const int rows = 10;
            const int cols = 10;

            // Initialize the field with random living cells
            bool[,] field = new bool[rows, cols];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = random.Next(2) == 1;
                }
            }

            // Output the initial state of the field
            OutputField(field);

            // Loop until the game is over
            bool gameOver = false;
            bool[,] previousField = field;
            while (!gameOver)
            {
                // Wait for user input
                Console.ReadLine();

                // Calculate the next generation of the field
                bool[,] nextField = new bool[rows, cols];
                bool changed = false;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        // Count the number of living neighbors
                        int livingNeighbors = 0;
                        for (int ii = -1; ii <= 1; ii++)
                        {
                            for (int jj = -1; jj <= 1; jj++)
                            {
                                if (ii == 0 && jj == 0) continue;
                                int ni = i + ii;
                                int nj = j + jj;
                                if (ni < 0 || ni >= rows || nj < 0 || nj >= cols) continue;
                                if (previousField[ni, nj]) livingNeighbors++;
                            }
                        }

                        // Apply the rules of the game
                        if (previousField[i, j] && (livingNeighbors == 2 || livingNeighbors == 3))
                        {
                            nextField[i, j] = true;
                        }
                        else if (!previousField[i, j] && livingNeighbors == 3)
                        {
                            nextField[i, j] = true;
                        }
                        else
                        {
                            nextField[i, j] = false;
                        }

                        // Check if the field has changed
                        if (nextField[i, j] != previousField[i, j])
                        {
                            changed = true;
                        }
                    }
                }

                // Output the new state of the field
                OutputField(nextField);

                // Check if the game is over
                if (!changed)
                {
                    Console.WriteLine("Game over");
                    gameOver = true;
                }

                // Update the previous field
                previousField = nextField;
            }
        }

        static void OutputField(bool[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j])
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("1 2 3 4 5 6 7 8 9");
        }
    }
}
