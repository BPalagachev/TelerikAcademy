using System;

class MatrixBottomLeftCorner
{
    static void Main()
    {
        Console.Write("Matrix Size: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int startRow = n-1 ;
        int startCol = 0;
        int row = startRow;
        int col = 0;
        int iterator = 1;
        int currentValue = 1;
        int diagSize = 0;
        for (int i = 0; i < n; i++)
        {

            for (int j = 0; j < iterator; j++)
            {
                row = startRow + j;
                col = startCol + j;
                matrix[row, col] = currentValue;
                currentValue++;

            }
            startRow--;
            iterator++;
        }
        startCol = 1;
        startRow = 0;
        iterator = n - 1;
        for (int i = 0; i < n-1; i++)
        {

            for (int j = 0; j < iterator; j++)
            {
                row = startRow + j;
                col = startCol + j;
                matrix[row, col] = currentValue;
                currentValue++;

            }
            startCol++;
            iterator--;
        }

        PrintMatrix(matrix);
    }
    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                Console.Write("{0,3}", matrix[row, cols]);
            }
            Console.WriteLine();
        }
    }
}