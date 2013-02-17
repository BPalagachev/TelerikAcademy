// Extend the program to support also subtraction and multiplication of polynomials.

using System;

class PolynomialsMultiplication
{
    static void Main()
    {
        Console.Write("Choose power of x: ");
        int power = int.Parse(Console.ReadLine());
        int[] poly1 = new int[power+1];
        int[] poly2 = new int[power + 1];
        Console.WriteLine("Input Coeficients for first polinomial: ");
        InputPoly(poly1);
        Console.WriteLine("Input Coeficients for second polinomial: ");
        InputPoly(poly2);
        Console.WriteLine("Multiplycation of the two polinomials resulted in: ");
        int[] result = MultiplyPoly(poly1, poly2);
        OutputArray(result);
        Console.WriteLine("Substraction of first and second polinomials resulted in: ");
        result = SubPoly(poly1, poly2);
        OutputArray(result);

    }
    static int[] AddPoly(int[] poly1, int[] poly2)
    {
        int[] result = new int[poly1.Length];
        for (int i = 0; i < poly1.Length; i++)
        {
            result[i] = poly1[i] + poly2[i];
        }
        return result;
    }
    static int[] SubPoly(int[] poly1, int[] poly2)
    {
        int[] result = new int[poly1.Length];
        for (int i = 0; i < poly1.Length; i++)
        {
            result[i] = poly1[i] - poly2[i];
        }
        return result;
    }
    static private int[] MultiplyPoly(int[] poly1, int[] poly2)
    {

        int resultLength = (poly1.Length+poly2.Length);
        int[] result = new int[resultLength];
        int offset = 0;
        for (int i = 0; i < poly2.Length; i++)
        {
            int[] temp = new int[resultLength];
            offset = 0;
            for (int j = poly1.Length-1; j>=0; j--)
            {
                int multiplication = poly2[poly2.Length-1-i]*poly1[j];
                temp[resultLength-1 - offset - i] = multiplication;
                offset++;
            }
            result = AddPoly(result, temp);
        }
        return result;
    }


    static void InputPoly(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("x^{0} :  ", array.Length-i-1);
            array[i] = int.Parse(Console.ReadLine());
        }
    }
    static void OutputArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("X^{0} : {1}", array.Length - i - 1, array[i]);
        }
    }
}