using System;

internal static class StatisticCalculator
{
    internal static double FindMaxValue(double[] sequence)
    {
        if (sequence ==  null || sequence.Length == 0)
        {
            throw new ArgumentException("Input data cannot be empty or null.");
        }
        else
        {
            double maxValue = sequence[0];

            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] > maxValue)
                {
                    maxValue = sequence[i];
                }
            }

            return maxValue;
        }
    }

    internal static double FindMinValue(double[] sequence)
    {
        if (sequence == null || sequence.Length == 0)
        {
            throw new ArgumentException("Input data cannot be empty or null.");
        }
        else
        {
            double minValue = sequence[0];

            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] < minValue)
                {
                    minValue = sequence[i];
                }
            }

            return minValue;
        }
    }

    internal static double FindAverage(double[] sequence)
    {
        if (sequence == null || sequence.Length == 0)
        {
            throw new ArgumentException("Input data cannot be empty or null.");
        }
        else
        {
            double currentSum = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                currentSum += sequence[i];
            }

            double averageValue = currentSum / sequence.Length;
            return averageValue;
        }
    }


}
