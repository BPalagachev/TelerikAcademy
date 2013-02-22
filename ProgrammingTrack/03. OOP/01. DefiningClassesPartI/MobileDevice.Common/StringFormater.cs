using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice.Common
{
    class StringFormater
    {
        // This class is used to format data from ToString Methods of the classes.
        // It could indent formated data keeping the row length

        private static int lineLength;
        private static string indentationString;
                
        internal static bool IsIndent {get; set;}
        internal static string IndentationString // this string would fit in frot of the formated data when indented
        {
            get
            {
                return indentationString;
            }
            set
            {
                if (value.Length >= lineLength)
                {
                    throw new ArgumentOutOfRangeException("Indentation string is longer then the length of line.");
                }
                indentationString = value;
            }
        }

        internal static char AlignmentSymbol { get; set; } // set which alignment symbol to use when centering text (creating title). eg dash(default) - "----Info----", or percent - "%%%%Info%%%%"
        internal static int LineLength // LineLength is the length of each row
        {
            get
            {
                return lineLength;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Line should be posivite number larger the zero!");
                }
                lineLength = value;
            }
        }

        static StringFormater()
        {
            AlignmentSymbol = '-'; 
            lineLength = 50;
            IndentationString = "   ";
            IsIndent = false;
        }
        private static string ProvideAlignmentSymbols(int numberOfSymbols) 
        {

            return new string(AlignmentSymbol, numberOfSymbols);
        }

        internal static string CenterTitle(string title) // used to center text for title. E.g. "-----Info-----"
        {
            int length = LineLength;
            StringBuilder centeredTitle = new StringBuilder();
            if (IsIndent)
            {
                length -= IndentationString.Length;
                centeredTitle.Append(indentationString);
            }
            int paddingLeft = (length - title.Length) / 2;
            if (paddingLeft < 0)
            {
                throw new ArgumentOutOfRangeException("Line length is too short!");
            }            
            centeredTitle.Append(ProvideAlignmentSymbols(paddingLeft));
            centeredTitle.Append(title);
            centeredTitle.Append(ProvideAlignmentSymbols(length - paddingLeft - title.Length));
            return centeredTitle.ToString();
        }
        internal static string FormatLine<T>(string description, T param) // Formats the data 
        {
            int lineLength = LineLength;
            string format = "{0,-alignmentLeft} - {1, alignmentRight}\n\r";

            if (IsIndent == true)
            {
                lineLength -= IndentationString.Length;
                format = IndentationString + format;
            }

            int alignmentLeft = (lineLength - 3) / 2;
            int alignmentRight = lineLength - 3 - alignmentLeft;
            format = format.Replace("alignmentRight", alignmentRight.ToString());
            format = format.Replace("alignmentLeft", alignmentLeft.ToString());
            if (param != null)
            {
                return String.Format(format, description, param);
            }
            else
            {
                return String.Format(format, description, "[Unknown]");
            }
        }
    }
}
