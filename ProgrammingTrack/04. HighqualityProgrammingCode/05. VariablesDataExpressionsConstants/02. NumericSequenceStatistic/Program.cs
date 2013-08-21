using System;

public class TestPrinter
{
    static void Main(string[] args)
    {
        double[] sequence = new double[] { 1, 2, 3, 4, 5 };

        StatisticsConsolePrinter.PrintMinValue(sequence);
        StatisticsConsolePrinter.PrintMaxValue(sequence);
        StatisticsConsolePrinter.PrintAverageValue(sequence);
    }
}
