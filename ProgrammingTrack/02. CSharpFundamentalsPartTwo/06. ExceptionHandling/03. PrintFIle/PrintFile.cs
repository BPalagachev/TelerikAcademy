// Write a program that enters file name along with its full file path
// (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. 
// Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch 
// all possible exceptions and print user-friendly error messages.

using System;
using System.IO;

class PrintFile
{
    static void Main()
    {
        // test file provided text.txt
        string textFilePath = Console.ReadLine();
        try
        {
            string text = File.ReadAllText(textFilePath);
            Console.WriteLine(text);
        }
        catch (ArgumentNullException ne)
        {
            Console.WriteLine(ne.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (PathTooLongException ptl)
        {
            Console.WriteLine(ptl.Message);
        }
        catch (DirectoryNotFoundException dnf)
        {
            Console.WriteLine(dnf.Message);
        }
        catch (FileNotFoundException fnf)
        {
            Console.WriteLine(fnf.Message);
        }
        catch (UnauthorizedAccessException ua)
        {
            Console.WriteLine(ua.Message);
        }
        catch (NotSupportedException ns)
        {
            Console.WriteLine(ns.Message);
        }
        finally
        {
            Console.WriteLine("Bye-Bye!");
        }
    }
}