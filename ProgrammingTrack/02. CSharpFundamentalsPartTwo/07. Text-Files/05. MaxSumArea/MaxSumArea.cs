// Write a program that reads a text file containing a square matrix of 
// numbers and finds in the matrix an area of size 2 x 2 with a maximal
// sum of its elements. The first line in the input file contains the 
// size of matrix N. Each of the next N lines contain N numbers separated 
// by space. The output should be a single number in a separate text file.
// Example:
//4
//2 3 3 4
//0 2 3 4			17
//3 7 1 2
//4 3 3 2

using System;
using System.IO;

class MaxSumArea
{
    static void Main()
    {
        string inputDateFile = @"..\..\input.txt";

        StreamReader reader = new StreamReader(inputDateFile);
        int[,] matrix;
        using (reader)
        {
            int rowCounter = 0;
            string line = reader.ReadLine();
            int matrixSize = int.Parse(line);
            matrix = new int[matrixSize, matrixSize];
            line = reader.ReadLine();
            while (line != null)
            {
                string[] numbers = line.Split(' ');
                for (int i = 0; i < numbers.Length; i++)
                {
                    matrix[rowCounter, i]= int.Parse(numbers[i]);
                }
                line=reader.ReadLine();
                rowCounter++;
            }
        }
        int maxSum = int.MinValue;
        int currentSum = 0;
        for (int row = 0; row < matrix.GetLength(0)-1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1)-1; col++)
            {
                for (int i = row; i < row+2; i++)
                {
                    for (int j = col; j < col+2; j++)
                    {
                        currentSum += matrix[i, j];
                    }
                }
                if (currentSum>maxSum)
                {
                    maxSum = currentSum;
                }
                currentSum=0;
            }
        }
        Console.WriteLine("Max sum in 2 by 2 area is: {0}!", maxSum);
    }
}
