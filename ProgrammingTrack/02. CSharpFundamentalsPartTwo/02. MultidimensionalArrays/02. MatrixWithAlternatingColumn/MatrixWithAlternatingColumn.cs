using System;

class MatrixWithAlternatingColumn
{
    static void Main(string[] args)
    {
        Console.Write("Matrix size: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int currentValue = 1;
        int direction = 1;
        int row = 0;
        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            while (row >= 0 && row < matrix.GetLength(1))
            {
                matrix[row, col] = currentValue;
                currentValue++;
                row += direction;
            }
            row = direction > 0 ? row - 1 : row + 1;
            direction *= -1;
           
            
           
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