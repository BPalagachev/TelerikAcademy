// Write a method that asks the user for his name and prints “Hello, <name>” 
// (for example, “Hello, Peter!”). Write a program to test this method.

using System;

class HelloName
{
    static void Main()
    {
        Hello();
    }
    static void Hello()
    {
        Console.Write("What is your name? - ");
        string usersName = Console.ReadLine();
        Console.WriteLine("Hello, {0}", usersName);
    }
}