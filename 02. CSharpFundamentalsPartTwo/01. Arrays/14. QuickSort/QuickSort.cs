using System;

public class QuickSort
{


    public static void Main()
    {
        Console.Write("Choose array size:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        InputArray(array);
        sort(array, 0, array.Length - 1);
        Console.WriteLine("Sorted Array: ");
        OutputArray(array);
    }

    static void InputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element:{0} = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static void OutputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Array[{0}] = {1}", i, array[i]);
        }
    }

    public static void sort(int[] array, int l, int r)
    {

        if (l >= r)
        {
            return;
        }

        int i = l;
        int j = r;
        int p = array[r];

        while (i < j)
        {
            while (i < j && array[i] <= p)
            {
                i++;
            }

            while (i < j && array[j] >= p)
            {
                j--;
            }

            if (i < j)
            {
                int h = array[i];
                array[i] = array[j];
                array[j] = h;

            }
        }
        int t = array[i];
        array[i] = array[r];
        array[r] = t;

        sort(array, l, i - 1);
        sort(array, i + 1, r);
    }

}
