using System;

class IntDoubleOrString
{
    static void Main()
    {
        Console.WriteLine("Type 'string' to enter a string value");
        Console.WriteLine("Type 'int' to enter an integer value");
        Console.WriteLine("Type 'double' to enter a double value");
        string userInput = Console.ReadLine();
        switch (userInput)
        {
            case "int": 
                int intValue = int.Parse(Console.ReadLine());
                intValue++;
                Console.WriteLine(intValue++);
                break;
            case "double":
                double doubleValue = double.Parse(Console.ReadLine());
                doubleValue++;
                Console.WriteLine(doubleValue);
                break;
            case "string":
                string strValue = Console.ReadLine() + "*";
                Console.WriteLine(strValue);
                break;
            default:
                Console.WriteLine("Unknown user input!");
                break;
        }
    }
}