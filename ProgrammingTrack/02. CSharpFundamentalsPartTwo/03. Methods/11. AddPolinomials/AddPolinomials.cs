// Write a method that adds two polynomials. Represent them as arrays of their coefficients.
using System;

class AddPolinomials
{
    static void Main()
    {
        Console.Write("Choose power of x: ");
        int power = int.Parse(Console.ReadLine());
        int[] poly1 = new int[power + 1];
        int[] poly2 = new int[power + 1];
        Console.WriteLine("Input Coeficients for first polynom: ");
        InputPoly(poly1);
        Console.WriteLine("Input Coeficients for second polynom: ");
        InputPoly(poly2);
        Console.WriteLine("Resulting polynom is: ");
        int[] result = AddPoly(poly1, poly2);
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
    static void InputPoly(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("x^{0} :  ", array.Length - i - 1);
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