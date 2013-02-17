using System;
using System.Globalization;
using System.Text;
using System.Threading;

class LeastMajorityMultiple
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int[] integerValues = new int[5];
        int devisableNumbers = 0;
        int majorityCondidate;
        for (int i = 0; i < integerValues.Length; i++)
        {
            integerValues[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(integerValues);

        majorityCondidate = integerValues[0];
        while (true)
        {

            for (int index = 0; index < integerValues.Length; index++)
            {
                if (majorityCondidate % integerValues[index] == 0)
                {
                    devisableNumbers++;
                }
                if (devisableNumbers >= 3)
                {
                    Console.WriteLine(majorityCondidate);
                    return;
                }
            }

            majorityCondidate++;
            devisableNumbers = 0;

        }
    }
}