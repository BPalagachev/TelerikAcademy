using System;
using System.Text;
using System.Threading;
using System.Globalization;

class MissCat2011
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int N = int.Parse(Console.ReadLine());
        int[] cats = new int[10];
        int vote = 0;
        int missCatVotes;
        int missCatIndex = 0;
        for (int i = 0; i < N; i++)
        {
            vote = int.Parse(Console.ReadLine());
            cats[vote-1]++;
        }
        missCatVotes = cats[9];
        for (int i = 9; i >= 0; i--)
        {
            if (missCatVotes <= cats[i])
            {
                missCatVotes = cats[i];
                missCatIndex = i;
            }
        }
        Console.WriteLine(missCatIndex+1);
    }
}