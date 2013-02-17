// Write a method ReadNumber(int start, int end) that enters an integer number 
// in given range [start…end]. If an invalid number or non-number text is entered,
// the method should throw an exception. Using this method write 
// a program that enters 10 numbers:
//                  a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class ReadNUmberInRange
{
    static void Main()
    {
        int number = new int();
        try
        {
            number = ReadNumber(0, 10);
        }
        catch (ArgumentException aor)
        {

            Console.WriteLine(aor.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye Dear Sir/Lady! ");
        }
    }
    static int ReadNumber(int startRange, int endRange)
    {
        int number = int.Parse(Console.ReadLine());
        if (number <= startRange || number>= endRange)
        {
            string messege = string.Format("Input number should be an integer number in range [{0} {1}] inclusive!", startRange, endRange);
            throw new ArgumentOutOfRangeException(messege);
        }
        return number;
    }
}