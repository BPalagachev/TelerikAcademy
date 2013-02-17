// You are given a sequence of positive integer values written into a string,
// separated by spaces. Write a function that reads these values from given 
// string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461

using System;

class SumOfString
{
    static void Main()
    {
        Console.WriteLine("Input numnber: ");
        string numbers = Console.ReadLine();
        string[] arrayOfNumber = numbers.Split(' ');
        int sum = 0;
        foreach (var item in arrayOfNumber)
        {
            sum += int.Parse(item);
        }
        Console.WriteLine("The sum is: {0}", sum);
    }
}