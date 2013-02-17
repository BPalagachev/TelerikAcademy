using System;

class ASCIITable
{
    static void Main()
    {
        Console.WriteLine("Char:\tCode\tHex");
        for (byte i = 0; i < 127; i++)
        {
            char symbol = (char)i;
            switch (symbol)
            {
                case '\t':
                    Console.WriteLine("Tab\t{0}\t{1}", i, i.ToString("X"));
                    break;
                case '\n':
                    Console.WriteLine("\\n\t{0}\t{1}", i, i.ToString("X"));
                    break;
                case ' ':
                    Console.WriteLine("Space\t{0}\t{1}", i, i.ToString("X"));
                    break;
                default:
                    Console.WriteLine("{0}\t{1}\t{2}", symbol, i, i.ToString("X"));
                    break;

            }
        }
    }
}

