using System;

class IsThirdDigit7
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine()); //1732
        bool isSeven = ((((number / 10) / 10) % 10) == 7);
        Console.WriteLine("Third digit in the number {0} is 7! -> {1}", number, isSeven);
    }
}
