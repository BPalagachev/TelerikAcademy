using System;

class SortRealValues
{
    static void Main()
    {
        float firstNumber = float.Parse(Console.ReadLine());
        float secondNumber = float.Parse(Console.ReadLine());
        float thirdNumber = float.Parse(Console.ReadLine());

        if (firstNumber >= secondNumber && firstNumber >= thirdNumber)
        {
            if (secondNumber >= thirdNumber)
            {
                Console.WriteLine("{0}, {1}, {2}", firstNumber, secondNumber, thirdNumber);
            }
            else
            {
                Console.WriteLine("{0}, {1}, {2}", firstNumber, thirdNumber, secondNumber);
            }
        }

        if (secondNumber >= firstNumber && secondNumber >= thirdNumber)
        {
            if (firstNumber >= thirdNumber)
            {
                Console.WriteLine("{0}, {1}, {2}", secondNumber, firstNumber, thirdNumber);
            }
            else
            {
                Console.WriteLine("{0}, {1}, {2}", secondNumber, thirdNumber, firstNumber);
            }
        }

        if (thirdNumber >= firstNumber && thirdNumber >= secondNumber)
        {
            if (firstNumber >= secondNumber)
            {
                Console.WriteLine("{0}, {1}, {2}", thirdNumber, firstNumber, secondNumber);
            }
            else
            {
                Console.WriteLine("{0}, {1}, {2}", thirdNumber, secondNumber, firstNumber);
            }
        }
    }
}