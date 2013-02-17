using System;

class MinMaxOfASequence
{
    static void Main()
    {
        int minValue = int.MaxValue;
        int maxValue = int.MinValue;
        Console.WriteLine("N = ?");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine("Input a sequence:");
        int[] sequence = new int[N];

        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = int.Parse(Console.ReadLine());
            if (minValue > sequence[i])
            {
                minValue = sequence[i];
            }
            if (maxValue < sequence[i])
            {
                maxValue = sequence[i];
            }
        }
        Console.WriteLine("Minimal value: {0}", minValue);
        Console.WriteLine("Maximal value: {0}", maxValue);
    }
}
