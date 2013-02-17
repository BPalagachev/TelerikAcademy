using System;

class Tubes
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int M = int.Parse(Console.ReadLine());
        int[] sizes = new int[N];
        for (int i = 0; i < N; i++)
        {
            sizes[i] = int.Parse(Console.ReadLine());
        }
        int start = 0;
        int end = MaxElement(sizes);
        int candidate = (end - start) / 2;
        int numberOfTubes = 0;
        int max = -1;

        while (start <= end)
        {
            numberOfTubes = 0;
            for (int i = 0; i < sizes.Length; i++)
            {
                numberOfTubes += sizes[i] / candidate;
            }
            if (numberOfTubes >= M)
            {
                start = candidate + 1;
                max = candidate;
            }
            else
            {
                end = candidate - 1;
            }
            candidate = start + (end - start) / 2;

        }
        Console.WriteLine(max);

    }
    static int MaxElement(int[] array)
    {
        int max = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (max < array[i])
            {
                max = array[i];
            }
        }
        return max;
    }
}