using System;

class SignOfProduct
{
    static void Main()
    {
        Console.WriteLine("Write three integer values to be multiplied:");
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());
        int minuses = 0;

        if (firstNumber < 0)
        {
            minuses++;
        }
        if (secondNumber < 0)
        {
            minuses++;
        }
        if (thirdNumber < 0)
        {
            minuses++;
        }
        
        if (minuses % 2 != 0 )
        {
            Console.WriteLine("Sign of the product is -");
        }
        else
        {
            Console.WriteLine("Sign of the product is +");
        }
    }
}