using System;

class BiggestOfThreeNubers
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());
        int biggestNumber = firstNumber;

        if (firstNumber <= secondNumber)
        {
            biggestNumber = secondNumber;
            if (biggestNumber < thirdNumber)
            {
                biggestNumber = thirdNumber;
            }
        }

        Console.WriteLine("Biggest number of the three is: {0}", biggestNumber);
    }
}