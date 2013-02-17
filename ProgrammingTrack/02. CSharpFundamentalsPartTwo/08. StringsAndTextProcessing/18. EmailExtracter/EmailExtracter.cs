// Write a program for extracting all email addresses from given text. 
// All substrings that match the format <identifier>@<host>…<domain>
// should be recognized as emails.

using System;
using System.Text.RegularExpressions;

class EmailExtracter
{
    static void Main()
    {
        string regExpression = @"[A-Za-z0-9]+@\w+\.\w{2,3}";
        string textContaingMails = @"bla bla blablablablalbla nqkakyw@email.com asdasdasdasasdsad drugEmailamaV@qhu.com asdsadasdasdasdasd
bla bla blablablablalbla rakiq@salata.co asdasdasdasasdsad dBatV@Stamat.bg asdsadasdasdasdasd
bla bla blablablablalbla Za@Nas.vas asdasdasdasasdsad Nevaliden-@meil.comes asdsadasdasdasdasd";
        MatchCollection mails = Regex.Matches(textContaingMails, regExpression);
        foreach (Match item in mails)
        {
            Console.WriteLine(item.Value);
        }

    }
}
