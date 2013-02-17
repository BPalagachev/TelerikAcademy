// We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several
// neighbor elements located on the same line, column or diagonal. Write a program that finds the longest
// sequence of equal strings in the matrix. Example
using System;

class SequenceInMatrix
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Matrix rows: ");
        //int rows = int.Parse(Console.ReadLine());
        //Console.WriteLine("Matrix cols: ");
        //int cols = int.Parse(Console.ReadLine());
        //Console.WriteLine("Input Matrix elements: ");
        //string[,] stringMatrix = new string[rows, cols];
        //for (int row = 0; row < stringMatrix.GetLength(0); row++)
        //{
        //    for (int col = 0; col < stringMatrix.GetLength(1); col++)
        //    {
        //        stringMatrix[row, col] = Console.ReadLine();
        //    }
        //}
        string[,] stringMatrix = new string[,]
        {
            {"aa", "bb", "aa", "bb"} ,
            {"bb", "zz", "bb", "bb"} ,
            {"zz", "cc", "zz", "bb"} ,
            {"zz", "cc", "aa", "zz"}
        };

        int c = 0;
        int r = 0;
        int counter = 1;
        int maxCoutner = 0;
        byte orientation = 0; // 1 - col, 2 - row, 3 - diag
        int indexCol = -1;
        int indexRow = -1;

        // check cols
        for (r = 0; r < stringMatrix.GetLength(0); r++)
        {
            while (c < stringMatrix.GetLength(1) - 1)
            {

                if (CompareStrings(stringMatrix[r, c], stringMatrix[r, c + 1]))
                {
                    counter++;
                    if (counter > maxCoutner)
                    {
                        maxCoutner = counter;
                        orientation = 1;
                        indexCol = c+2-maxCoutner;
                        indexRow = r;
                    }
                }
                else
                {
                    counter = 1;
                }
                c++;
            }
            c = 0;
            counter = 1;
        }

        // check diags
        int startingRow = 0;
        int startingCol = 0;
        counter = 1;
        c= 0;
        r = 0;
        for (int i = 1; i < stringMatrix.GetLength(1); i++)
        {
            while (c < stringMatrix.GetLength(1))
            {
                if (r >= stringMatrix.GetLength(0) - 1 || c >= stringMatrix.GetLength(1) - 1)
                {
                    break;
                }
                if (stringMatrix[r, c] == stringMatrix[r + 1, c + 1])
                {
                    counter++;
                    if (counter > maxCoutner)
                    {
                        maxCoutner = counter;
                        orientation = 3;
                        indexCol = c + 2 - maxCoutner;
                        indexRow = r + 2 - maxCoutner;
                    }
                }
                else
                {
                    counter = 1;
                }
                c++;
                r++;
            }
            c = i;
            r = 0;
        }
        

        Console.WriteLine(indexCol);
        Console.WriteLine(indexRow);

        for (int row = 0; row < stringMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < stringMatrix.GetLength(1); col++)
            {
                Console.Write(stringMatrix[row, col] + "     ");
            }
            Console.WriteLine();
        }

    }

    static bool CompareStrings(string str1, string str2)
    {
        if (str1.Length != str2.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }
        }
        return true;
    }
}