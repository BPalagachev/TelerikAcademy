// Write a program that reads an integer number and calculates 
// and prints its square root. If the number is invalid or 
// negative, print "Invalid number". In all cases finally 
// print "Good bye". Use try-catch-finally.

using System;

class CalcSqrt
{
    static void Main()
    {
        double number = 0;
        try
        {
            number = double.Parse(Console.ReadLine());
            Console.WriteLine("Sqrt of {0} is {1}!", number, Sqrt(number));
        }
        catch (ArgumentNullException ne)
        {
            Console.WriteLine(ne.Message);

        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch (OverflowException of)
        {
            Console.WriteLine(of.Message);
        }
        catch (ArgumentOutOfRangeException aor)
        {
            Console.WriteLine(aor.Message);
        }
        finally
        {
            Console.WriteLine("Goodbye Dear Sir/Lady! ");
        }
    }
    static double Sqrt(double number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("Sqrt for negative number is not defined!");
        }
        return Math.Sqrt(number);
    }
}