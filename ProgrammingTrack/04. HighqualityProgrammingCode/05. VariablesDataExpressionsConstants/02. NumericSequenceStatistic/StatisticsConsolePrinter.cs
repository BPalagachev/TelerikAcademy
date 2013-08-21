using System;

public static class StatisticsConsolePrinter
{
    public static void PrintMinValue(double[] sequence)
    {
        if (sequence == null)
        {
            throw new ArgumentNullException();
        }

        double minValue = StatisticCalculator.FindMinValue(sequence);
        Console.WriteLine(minValue);
    }

    public static void PrintMaxValue(double[] sequence)
    {
        if (sequence == null)
        {
            throw new ArgumentNullException();
        }

        double maxValue = StatisticCalculator.FindMaxValue(sequence);
        Console.WriteLine(maxValue);
    }

    public static void PrintAverageValue(double[] sequence)
    {
        if (sequence == null)
        {
            throw new ArgumentNullException();
        }

        double averageValue = StatisticCalculator.FindAverage(sequence);
        Console.WriteLine(averageValue);
    }
}
