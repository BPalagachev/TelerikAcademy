using System;

class CopyrightTriangle
{
    static void Main()
    {
        char copyRight = '\u00A9';
        Console.WriteLine(
@"  {0}   
 {0} {0}
{0}{0}{0}{0}{0}", copyRight);
    }
}