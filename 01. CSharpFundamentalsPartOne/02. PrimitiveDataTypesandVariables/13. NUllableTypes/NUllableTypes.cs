using System;

class NUllableTypes
{
    static void Main()
    {
        int? nullalbeInt = null;
        double? nullaleDouble = null;
        Console.WriteLine(nullalbeInt);
        Console.WriteLine(nullaleDouble);
        Console.WriteLine(nullalbeInt+5);           // result is null
        Console.WriteLine(nullaleDouble + 5.0);     // result is null
        Console.WriteLine(nullalbeInt + null);      // result is null
        Console.WriteLine(nullaleDouble + null);    // result is null
    }
}