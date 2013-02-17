using System;

class CompareWithPrecision
{
    static void Main()
    {
        double compareArg1 = 5.00000001;
        double compareArg2 = 5.00000003;
        double precision = 0.000001;
        Console.WriteLine("({0}; {1}) -> {2}", compareArg1, compareArg2, (Math.Abs((compareArg1 - compareArg2)) < precision) );
    }
}

