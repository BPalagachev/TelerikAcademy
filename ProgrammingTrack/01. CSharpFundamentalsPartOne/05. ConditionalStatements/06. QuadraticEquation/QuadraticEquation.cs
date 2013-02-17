using System;

class QuadraticEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double Discriminant, sqrtOfDiscriminant;
        double root1, root2;

        Discriminant = b * b - 4 * a * c;
        if ( (sqrtOfDiscriminant = Math.Sqrt(Discriminant)) > 0)
        {
            root1 = (-b + sqrtOfDiscriminant) / (2 * a);
            root2 = (-b - sqrtOfDiscriminant) / (2 * a);
            Console.WriteLine("There are two real roots");
            Console.WriteLine("Root1 = {0}", root1);
            Console.WriteLine("Root2 = {0}", root2);
        }
        else if (sqrtOfDiscriminant == 0)
        {
            root1 = (-b) / (2 * a);
            root2 = root1;
            Console.WriteLine("There is one real root: {0}", root1);
        }
        else
        {
            Console.WriteLine("There are no real roots!");
        }

    }
}