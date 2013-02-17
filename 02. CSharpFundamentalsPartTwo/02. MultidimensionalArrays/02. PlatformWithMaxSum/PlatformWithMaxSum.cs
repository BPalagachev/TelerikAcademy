// Write a program that reads a rectangular matrix of size
// N x M and finds in it the square 3 x 3 that has maximal sum of its elements

using System;

class PlatformWithMaxSum
{
    static void Main()
    {
        Console.Write("How many rows: ");
        int numberOfRows = int.Parse(Console.ReadLine());
        Console.Write("How many cols: ");
        int numberOfCols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[numberOfRows, numberOfCols];
        int xIndexOfMaxPlatform = -1;
        int yIndexOfMaxPlatform = -1;
        int sizeOfMaxPlatform = 3;
        int sumOfMaxPlatform = int.MinValue;
        int currentSum = 0;

        Console.WriteLine("Input matrix elements: ");
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < matrix.GetLength(1); cols++)
            {
                Console.Write("Element[{0},{1}] = ", rows, cols);
                matrix[rows, cols] = int.Parse(Console.ReadLine());
            }
        }

        for (int rows = 0; rows <= matrix.GetLength(0) - sizeOfMaxPlatform; rows++)
        {
            for (int cols = 0; cols <= matrix.GetLength(1) - sizeOfMaxPlatform; cols++)
            {
                for (int hor = rows; hor < rows + sizeOfMaxPlatform; hor++)
                {
                    for (int ver = cols; ver < cols + sizeOfMaxPlatform; ver++)
                    {
                        currentSum += matrix[hor, ver];
                    }
                }
                if (currentSum > sumOfMaxPlatform)
                {
                    sumOfMaxPlatform = currentSum;
                    xIndexOfMaxPlatform = cols;
                    yIndexOfMaxPlatform = rows;
                }
                currentSum = 0;
            }
        }
        if (yIndexOfMaxPlatform >= 0 && xIndexOfMaxPlatform >= 0)
        {
            PrintMatrix(matrix, yIndexOfMaxPlatform, yIndexOfMaxPlatform + sizeOfMaxPlatform, xIndexOfMaxPlatform, xIndexOfMaxPlatform + sizeOfMaxPlatform);
        }
        else
        {
            Console.WriteLine("Input matrix is too small to have 3 by 3 platform");
        }


    }
    static void PrintMatrix(int[,] matrix, int startingRow, int endingRow, int startingCol, int endingCol)
    {
        for (int row = startingRow; row < endingRow; row++)
        {
            for (int cols = startingCol; cols < endingCol; cols++)
            {
                Console.Write("{0,3}", matrix[row, cols]);
            }
            Console.WriteLine();
        }
    }
}