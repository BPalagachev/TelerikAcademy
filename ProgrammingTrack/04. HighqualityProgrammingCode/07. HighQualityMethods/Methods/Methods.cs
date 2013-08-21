using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        static string DigitToWord(int number)
        {
            string digitNameInEnglish = string.Empty;
            switch (number)
            {
                case 0: digitNameInEnglish = "zero";
                    break;
                case 1: digitNameInEnglish = "one";
                    break;
                case 2: digitNameInEnglish = "two";
                    break;
                case 3: digitNameInEnglish = "three";
                    break;
                case 4: digitNameInEnglish = "four";
                    break;
                case 5: digitNameInEnglish = "five";
                    break;
                case 6: digitNameInEnglish = "six";
                    break;
                case 7: digitNameInEnglish = "seven";
                    break;
                case 8: digitNameInEnglish = "eight";
                    break;
                case 9: digitNameInEnglish = "nine";
                    break;
                default:
                    throw new ArgumentException("Input should be a digit in decimal numeral system!");
            }

            return digitNameInEnglish;
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Input cannot be null or an empty array!");
            }

            int maxValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (maxValue < elements[i])
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }

        public enum FormatOptions
        {
            TwoDigitsPrecision,
            AsPercentage,
            Indented
        }

        static void PrintAndFormatRealNumber(double number, FormatOptions formatOptions)
        {

            switch (formatOptions)
            {
                case FormatOptions.TwoDigitsPrecision:
                    Console.WriteLine("{0:f2}", number);
                    break;
                case FormatOptions.AsPercentage:
                    Console.WriteLine("{0:p0}", number);
                    break;
                case FormatOptions.Indented:
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Unknow formatting");
                    break;
            }
        }

        public struct Point2D
        {
            public double XCoord { get; set; }
            public double YCoord { get; set; }
        }

        static double CalcDistance(Point2D firstPoint, Point2D secondPoint,
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (firstPoint.YCoord == secondPoint.YCoord);
            isVertical = (firstPoint.XCoord == secondPoint.YCoord);

            double distanceProjectedOnX = secondPoint.XCoord - firstPoint.XCoord;
            double distanceProectedOnY = secondPoint.YCoord - firstPoint.YCoord;
            double distance = Math.Sqrt(distanceProjectedOnX * distanceProjectedOnX + distanceProectedOnY * distanceProectedOnY);

            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToWord(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAndFormatRealNumber(1.3, FormatOptions.TwoDigitsPrecision);
            PrintAndFormatRealNumber(0.75, FormatOptions.AsPercentage);
            PrintAndFormatRealNumber(2.30, FormatOptions.Indented);


            Point2D firstTestPoint = new Point2D() { XCoord = 3.0, YCoord = -1.0 };
            Point2D secondTestPoint = new Point2D(){XCoord =3.0, YCoord = 2.5};
            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(firstTestPoint, secondTestPoint, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student( "Peter", "Ivanov", "17.03.1992", "From Sofia" );

            Student stella = new Student("Stella", "Markova", "03.11.1993");
            stella.AdditionalInformation = "From Vidin, gamer, high results";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
