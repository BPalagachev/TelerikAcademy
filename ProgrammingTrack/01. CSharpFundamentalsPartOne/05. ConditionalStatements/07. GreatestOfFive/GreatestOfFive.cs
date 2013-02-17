using System;

class GreatestOfFive
{
    static void Main()
    {
        int[] fiveVariables = new int[5];
        int greatestVariable = int.MinValue;

        for (int i = 0; i < fiveVariables.Length; i++)
        {
            fiveVariables[i] = int.Parse(Console.ReadLine());
            if (greatestVariable < fiveVariables[i])
            {
                greatestVariable = fiveVariables[i];
            }
        }
        Console.WriteLine("The greatest variable is: {0}", greatestVariable);
    }
}