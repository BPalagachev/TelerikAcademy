using System;

class FirstNMembersOfASequence
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int X = int.Parse(Console.ReadLine());
        double sum = 1;
        for (int i = 1; i <= N; i++)
        {
            sum += factorial(i) / Math.Pow(X, i);
        }
        Console.WriteLine(sum);
    }
    static int factorial(int number)
    {
        int factorial = 1;
        while (number > 0)
        {
            factorial *= number--;
        }
        return factorial;
    }
}