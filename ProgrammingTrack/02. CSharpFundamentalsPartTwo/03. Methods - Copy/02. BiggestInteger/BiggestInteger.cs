// Write a method GetMax() with two parameters that returns the bigger of
// two integers. Write a program that reads 3 integers from the console
// and prints the biggest of them using the method GetMax().

using System;

class BiggestInteger
{
    static void Main()
    {
        Console.Write("Number One: ");
        int numberOne = int.Parse(Console.ReadLine());
        Console.Write("Number Two: ");
        int numberTwo = int.Parse(Console.ReadLine());
        Console.Write("Number Three: ");
        int numberThree = int.Parse(Console.ReadLine());

        Console.WriteLine("The biggest of the three is: {0}", GetMax(numberOne, GetMax(numberTwo,numberThree)));
    }
    static int GetMax(int numberOne, int numberTwo)
    {
        return numberOne >= numberTwo ? numberOne : numberTwo;
    }
}