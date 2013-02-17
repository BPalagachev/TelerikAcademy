// Write a program to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d).
// Example of incorrect expression: )(a+b)).

using System;
using System.Text;

class Brackets
{
    static void Main()
    {
        string expression = Console.ReadLine();
        int counter = 0;
        foreach (char item in expression)
        {
            if (item =='(')
            {
                counter++;
            }
            else if (item==')')
            {
                counter--;
            }
            if (counter < 0)
            {
                Console.WriteLine("Unbalanced brackets!");
                return;
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("Expression corrent!");
        }
        else
        {
            Console.WriteLine("Unbalanced brackets!");

        }
        
    }
}