using System;

class CastingStringObject
{
    static void Main()
    {
        string hello = "Hello";
        string world = "world";
        object helloWorld = (object)(hello + " " + world);
        string helloWorldString = (string)helloWorld;
    }
}

