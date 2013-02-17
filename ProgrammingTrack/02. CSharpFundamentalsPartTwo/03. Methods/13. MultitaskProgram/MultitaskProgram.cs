// Write a program that can solve these tasks:
// Reverses the digits of a number
// Calculates the average of a sequence of integers
// Solves a linear equation a * x + b = 0
//        Create appropriate methods.
//        Provide a simple text-based menu for the user to choose which task to solve.
//        Validate the input data:
// The decimal number should be non-negative
// The sequence should not be empty
// a should not be equal to 0

using System;

class MultitaskProgram
{
    static void Main()
    {
        while (true)
        {
            Menu();
            char choice = char.Parse(Console.ReadLine());
            switch (choice)
            {
                case '1':
                    Console.WriteLine("Enter your number:");
                    try
                    {
                        int number = int.Parse(Console.ReadLine());
                        Console.WriteLine("-> {0}", ReverseDigits(number));
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    break;
                case '2':
                    try
                    {
                        Console.Write("Array size: ");
                        int arraySize = int.Parse(Console.ReadLine());
                        int[] array = new int[arraySize];
                        InputArray(array);
                        Console.WriteLine("The averige is: {0}", CalcAverige(array));
                        
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case '3':
                    try
                    {
                        Console.Write("a = ");
                        double a = double.Parse(Console.ReadLine());
                        Console.Write("b = ");
                        double b = double.Parse(Console.ReadLine());
                        Console.WriteLine("Solution: {0}", SolveLinearEquation(a,b));

                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case '0':
                    return;
                    break;
            }
        }
       
    }
    


    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element[{0}] =  ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static int ReverseDigits(int number)
    {
        if (number<0)
        {
            
            throw new ArgumentOutOfRangeException() ;
        }
        int newNumber = 0;
        while (number > 0)
        {
            newNumber *= 10;
            newNumber += number % 10;
            number /= 10;
        }
        return newNumber;
    }
    static int CalcAverige(int[] array)
    {
        if (array.Length <= 0)
        {

            throw new ArgumentOutOfRangeException();
        }
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum / array.Length;
    }
    static double SolveLinearEquation(double a, double b)
    {
        if (a == 0)
        {

            throw new ArgumentOutOfRangeException();
        }
        return -b / a;
    }

    static void Menu()
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("To reverse the digits of a number - Press 1");
        Console.WriteLine("To Calculate the average of a sequence of integers - press 2");
        Console.WriteLine("To solves a linear equation a * x + b = 0 - press 3");
        Console.WriteLine("To Exit press 0");
        Console.WriteLine(new string('-', 40) );
    }
}

