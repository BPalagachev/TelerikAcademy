// Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
// Display them in the standard date format for Canada.

using System;
using System.Text.RegularExpressions;
using System.Globalization;

class CanadianFormat
{
    static void Main()
    {
        string textContainingDates = @"15.12.2015Lorem Ipsum е елементарен примерен текст, използван в печ15.12.2015атарската и типографската индустр15.12.2015ия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печ15.15.1атар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. ";
        string regExpression = @"\d{2}.\d{2}.\d{4}";
        MatchCollection matches = Regex.Matches(textContainingDates, regExpression);
        foreach (Match item in matches)
        {
            DateTime canadianDate = DateTime.ParseExact(item.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(canadianDate.ToString(new CultureInfo("en-CA")));
        }
    }
}