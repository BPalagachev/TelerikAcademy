// Write a method that returns the last digit of given integer 
// as an English word. Examples: 512  "two", 1024  "four", 12309  "nine".

using System;

class LastDigit
{
    static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(GetDigitName(GetLastDigit(number)));

    }
    static int GetLastDigit(int number)
    {
        return number % 10;

    }
    static string GetDigitName(int digit)
    {
        switch (digit)
        {
            case 0:
                return "zero";
                break;
            case 1:
                return "one";
                break;
            case 2:
                return "two";
                break;
            case 3:
                return "three";
                break;
            case 4:
                return "four";
                break;
            case 5:
                return "five";
                break;
            case 6:
                return "six";
                break;
            case 7:
                return "seven";
                break;
            case 8:
                return "eight";
                break;
            case 9:
                return "nine";
                break;
            default: 
                return "Not a digit";
                break;


        }
    }
}