using System;

class MatrixWithLeadingColumn
{
    static void Main(string[] args)
    {
        Console.Write("Matrix size: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n,n];
        int currentValue = 1;
        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                matrix[row, col] = currentValue;
                currentValue++;
            }
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