using System;
using System.Text;
using System.Threading;
using System.Globalization;

class Pillars
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        byte pilarIndex = 7;
        int leftCounter = 0;
        int rightCounter = 0;

        byte[] lines = new byte[8];
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = byte.Parse(Console.ReadLine());
        }

        while (pilarIndex > 0)
        {
            for (int left = 7; left > pilarIndex; left--)
            {
                for (int i = 0; i < 8; i++)
                {
                    //leftCounter += (lines[i] >> left) & 1;
                    if ((lines[i] & (1 << left)) != 0)
                    {
                        leftCounter++;
                    }
                }
            }
            for (int right = 0; right < pilarIndex; right++)
            {
                for (int i = 0; i < 8; i++)
                {
                    //rightCounter += (lines[i] >> right) & 1;
                    if ((lines[i] & (1 << right)) != 0)
                    {
                        rightCounter++;
                    }
                }
            }
            if (leftCounter==rightCounter)
            {
                Console.WriteLine(pilarIndex);
                Console.WriteLine(rightCounter);
                return;
            }
            pilarIndex--;
            leftCounter = 0;
            rightCounter = 0;
        }
        Console.WriteLine("No");

    }
}