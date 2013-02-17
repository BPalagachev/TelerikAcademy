using System;
using System.Collections.Generic;
using System.Text;

class SevenSegmentDigits
{

    static void Main(string[] args)
    {
        int[] toPrint;
        int N = int.Parse(Console.ReadLine());
        string[] states = new string[N];
        for (int i = 0; i < N; i++)
        {
            states[i] = Console.ReadLine();
        }

        bool[,] digits = new bool[N, 10];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (states[i][j] == '1')
                {
                    Segments(i, j, digits);
                }


            }

        }
        CalcCombination(digits);
        toPrint = new int[N];
        DisplayResult(digits, 0, toPrint);
        //PrintList(toPrint,N);

    }

    static void Segments(int digit, int diodPosition, bool[,] table)
    {
        switch (diodPosition)
        {
            case 0: // A
                table[digit, 1] = true;
                table[digit, 4] = true;
                break;
            case 1: // B
                table[digit, 5] = true;
                table[digit, 6] = true;
                break;
            case 2: // C
                table[digit, 2] = true;
                break;
            case 3: // D
                table[digit, 1] = true;
                table[digit, 4] = true;
                table[digit, 7] = true;
                break;
            case 4: // E
                table[digit, 1] = true;
                table[digit, 3] = true;
                table[digit, 4] = true;
                table[digit, 5] = true;
                table[digit, 7] = true;
                table[digit, 9] = true;
                break;
            case 5: // F
                table[digit, 1] = true;
                table[digit, 2] = true;
                table[digit, 3] = true;
                table[digit, 7] = true;
                break;
            case 6: // G
                table[digit, 0] = true;
                table[digit, 1] = true;
                table[digit, 7] = true;
                break;
        }
    }

    static void DisplayResult(bool[,] table, int top, int[] toPrint)
    {

        if (top > table.GetLength(0) - 1)
        {
            PrintList(toPrint);
            return;
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (table[top, i] == false)
                {
                    toPrint[top] = i;
                    DisplayResult(table, top + 1, toPrint);
                }

            }
        }

    }
    static void PrintList(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);



        }
        Console.WriteLine();
    }
    static void CalcCombination(bool[,] matrix)
    {
        int combination = 1;
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == false)
                {
                    count++;
                }

            }
            combination *= count;
            count = 0;
        }
        Console.WriteLine(combination);
    }
}