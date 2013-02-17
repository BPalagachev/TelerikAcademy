using System;

class EuclideanAlgorithm
{
    static void Main()
    {
        int numberOne = int.Parse(Console.ReadLine());
        int numberTwo = int.Parse(Console.ReadLine());
        int reminder = 1;

        while (reminder != 0)
        {
            reminder = numberOne % numberTwo;
            numberOne = numberTwo;
            numberTwo = reminder;
        }
        Console.WriteLine(numberOne);
    }
}