using System;
using System.Diagnostics;

class Program
{
    delegate void ActionToTest(dynamic operand1);

    static void Main(string[] args)
    {
        // Test sqrt
        Console.WriteLine("-------- Test sqrt --------");
        Console.WriteLine("Test sqrt with floats: ");
        DisplayExecutionTime(TestSqrt, 1000f);
        Console.WriteLine("Test sqrt with doubles: ");
        DisplayExecutionTime(TestSqrt, 1000d);
        Console.WriteLine("Test sqrt with decimals: ");
        DisplayExecutionTime(TestSqrt, (double)1000m);
        
        // Test sinus
        Console.WriteLine("-------- Test sinus --------");
        Console.WriteLine("Test sinus with floats: ");
        DisplayExecutionTime(TestSinis, 1000f);
        Console.WriteLine("Test sinus with doubles: ");
        DisplayExecutionTime(TestSinis, 1000d);
        Console.WriteLine("Test sinus with decimals: ");
        DisplayExecutionTime(TestSinis, (double)1000m);

        // Test ln
        Console.WriteLine("-------- Test ln --------");
        Console.WriteLine("Test ln with floats: ");
        DisplayExecutionTime(TestSinis, 1000f);
        Console.WriteLine("Test ln with doubles: ");
        DisplayExecutionTime(TestSinis, 1000d);
        Console.WriteLine("Test ln with decimals: ");
        DisplayExecutionTime(TestSinis, (double)1000m);
 
    }

    static void DisplayExecutionTime(ActionToTest action, dynamic operand1)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < 1000000; i++)
        {
            action(operand1);
        }
        Console.WriteLine("{0,-10}", stopwatch.Elapsed);
    }

    static void TestSqrt(dynamic operand1)
    {
        Math.Sqrt(operand1);
    }

    static void TestSinis(dynamic operand1)
    {
        Math.Sin(operand1);
    }

    static void TestLn(dynamic operand1)
    {
        Math.Log(operand1);
    }
}
