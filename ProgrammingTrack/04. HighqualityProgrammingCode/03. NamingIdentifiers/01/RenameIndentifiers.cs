using System;

class ClassWithNoClearPurpose
{
    const int MaxCount = 6;

    class BooleanConsolePrinter
    {
        public void Print(bool boolean)
        {
            string boolAsString = boolean.ToString();

            Console.WriteLine(boolAsString);
        }
    }

    public static void Initialize()
    {
        ClassWithNoClearPurpose.BooleanConsolePrinter boolPrinter = new ClassWithNoClearPurpose.BooleanConsolePrinter();
        boolPrinter.Print(true);
    }
}
