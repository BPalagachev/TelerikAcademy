using System;
using System.Text;

class CSharpCleanCode
{
    static void Main()
    {
        StringBuilder temp = new StringBuilder();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            temp.Append(Console.ReadLine());
            temp.Append("\r\n");
        }

        //        string peshosCode =
        //@"using System; // no comment...
        //class JustClass
        //{ /* Just
        //multiline
        //comment */private void JustMethod()
        //{
        //// string str=""inception/*//*/"";
        //} 
        //}";
        string peshosCode = temp.ToString();
        bool inString = false;
        bool inInlineComent = false;
        bool inMultiLineComment = false;
        StringBuilder cleanCode = new StringBuilder();
        for (int i = 0; i < peshosCode.Length - 2; i++)
        {
            if (peshosCode[i] == '\"' && (!inInlineComent && !inMultiLineComment))
            {
                inString = !inString;
            }
            if (inString)
            {

            }
            else
            {
                if (inInlineComent == false)
                {
                    if (peshosCode[i] == '/' && peshosCode[i + 1] == '/')
                    {
                        inInlineComent = !inInlineComent;
                    }
                }
                else
                {
                    if (peshosCode[i] == '\r' && peshosCode[i + 1] == '\n')
                    {
                        inInlineComent = !inInlineComent;
                    }
                }

                if (peshosCode[i] == '/' && peshosCode[i + 1] == '*')
                {
                    inMultiLineComment = true;
                }
                else if (peshosCode[i] == '*' && peshosCode[i + 1] == '/')
                {
                    i += 2;
                    inMultiLineComment = false;
                }

            }
            if (!inInlineComent && !inMultiLineComment)
            {
                cleanCode.Append(peshosCode[i]);
            }

        }
        Console.WriteLine(new string('-', 20));
        string toDisplay = cleanCode.ToString();
        string[] lines = toDisplay.Split('\n');
        foreach (var item in lines)
        {
            //if (!string.IsNullOrWhiteSpace(item))
            //{
            //    Console.WriteLine(item.Trim());
            //}
            Console.WriteLine(item.Trim());
        }


        //Console.WriteLine(cleanCode);
    }

}