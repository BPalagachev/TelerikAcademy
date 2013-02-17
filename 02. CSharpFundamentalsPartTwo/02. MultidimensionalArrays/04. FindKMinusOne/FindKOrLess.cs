// Write a program, that reads from the console an array of N integers and an 
// integer K, sorts the array and using the method Array.BinSearch() finds the 
// largest number in the array which is ≤ K. 


using System;

class FindKOrLess
{
    static void Main()
    {
        Console.Write("Array Size: ");
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(array);
        int errorMin = int.MaxValue;
        int currentError = 0;
        int indexOfMinError = -1;
        Console.Write("K = ");
        int K = int.Parse(Console.ReadLine());
       
        for (int i = 0; i < array.Length; i++)
        {
            currentError = Math.Abs(array[i] - K);
            if (currentError < errorMin)
            {
                errorMin = currentError;
                indexOfMinError = i;
            }
            if (errorMin == 0)
            {
                indexOfMinError--;
                break;
            }
            
        }
        Console.WriteLine(array[indexOfMinError]);

        

    }
}