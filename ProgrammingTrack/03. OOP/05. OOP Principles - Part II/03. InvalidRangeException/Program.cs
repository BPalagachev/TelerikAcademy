using System;

namespace _03.InvalidRangeException
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = 7;
            if (number <= 1 || number >= 100)
            {
                throw new InvalidRangeException<int>(0, 5, "Number must be in allowed range! ");
            }

            DateTime date = new DateTime(2014, 03, 1);
            DateTime start = new DateTime(1980, 1, 1);
            DateTime end = new DateTime(2013, 12, 31);

            if (date <= start || date >= end)
            {
                throw new InvalidRangeException<DateTime>(start, end, "Number must be in allowed range! "); 
            }
        }
    }
}
