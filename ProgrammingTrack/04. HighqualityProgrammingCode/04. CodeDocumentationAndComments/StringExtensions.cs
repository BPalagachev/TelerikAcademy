namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        /// <summary>
        /// Computes the MD5 hash value for a string <see cref="System.String"/> value. The method uses <see cref="T:System.Security.Cryptography.MD5"/>.
        /// </summary>
        /// <returns>Returns string value containing the resulting hash code.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }


        /// <summary>
        /// Returns a boolean value depending on the current string value.
        /// </summary>
        /// <remarks>"true", "ok", "yes", "1", "да" are parsed to true, every other value - to false.</remarks>
        /// <returns>Return a bool <see cref="System.Boolean"/> value.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Parses string to short <see cref="System.Int16"/>.
        /// </summary>
        /// <remarks>The method will return null in case of incorrect input data e.g. 
        /// when parsing fails - see short.TryParse() <see cref="System.Int16.TryParse()"/> for more detailed information.</remarks>
        /// <returns>Returns a short <see cref="System.Int16"/> or null in case of incorrect input data.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Parses string to int <see cref="System.Int32"/>.
        /// </summary>
        /// <remarks>The method will return null in case of incorrect input data e.g. 
        /// when parsing fails - see int.TryParse() <see cref="System.Int64.TryParse"/> for more detailed information.</remarks>
        /// <returns>Returns an int <see cref="System.Int64"/> or null in case of incorrect input data.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Parses string to long <see cref="System.Int64"/>.
        /// </summary>
        /// <remarks>The method will return null in case of incorrect input data e.g.
        /// when parsing fails - see long.TryParse() <see cref="System.Int32.TryParse"/> for more detailed information.</remarks>
        /// <returns>Returns a long <see cref="System.Int32"/> or null in case of incorrect input data.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Parses string to DateTime <see cref="System.DateTime"/>.
        /// </summary>
        /// <remarks>The method will return null in case of incorrect input data e.g. 
        /// when parsing fails - seeDateTime.Parse() <see cref="System.DateTime.TryParse"/> for more detailled information.</remarks>
        /// <returns>Returns a DateTime <see cref="System.DateTime"/> or null in case of incorrect input data.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>Returns a copy of this <see cref="T:System.String"/> object with first letter converted 
        /// to uppercase using the casing rules of the current culture.</summary>
        /// <returns>The capitalized first letter equivalent of the current string.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns a copy of the string <see cref="T:System.String"/> located between two words in the current string - 
        /// startString and endString.
        /// </summary>
        /// <param name="input">The current string.</param>
        /// <param name="startString">First, opening word.</param>
        /// <param name="endString">Second, closing word</param>
        /// <param name="startFrom">Sets the initial, start position int the current string for the search.
        /// This parameter is not mandatory. 0 by default.</param>
        /// <returns>Returns a copy of the string located between startString and endString in the current string.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>Returns a copy of this <see cref="T:System.String"/> object corresponding to the input string 
        /// with all Cyrillic letters replaced with their Latin equivalent.
        /// </summary>
        /// <returns>Returns a copy of the current string with all Cyrillic letters replaced with their Latin equivalent</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                // for all occuerences of cyrillic letters in the string, replace them with their latin equivalent. Both lower and upper register.
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>Returns a copy of this <see cref="T:System.String"/> object corresponding to the input string 
        /// with all Latin letters replaced with their Cyrillic equivalent.
        /// </summary>
        /// <returns>Returns a copy of the current string with all Latin letters replaced with their Cyrillic equivalent</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                // for all occuerences of lattin letters in the string, replace them with their cyrillic equivalent. Both lower and upper register.
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Returns a copy of this <see cref="T:System.String"/> object. It contains a valid user name. 
        /// A valid user name is considered a string that does not contain symbols that differ from 
        /// Latin letters (both registers), digits, underscores or dots.
        /// This methods converts all Cyrillic letters to their Latin equivalent before removing the invalid symbols.
        /// This method does not alter the input string.
        /// </summary>
        /// <remarks>
        /// This method replaces with string.Empty <see cref="System.String.Empty"/> all matches
        /// of the following regular expression [^a-zA-z0-9_\.]+ .
        /// </remarks>
        /// <returns>Returns a string containing a valid username.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Returns a copy of this <see cref="T:System.String"/> object. It contains a valid Latin name.
        /// A valid Latin name is consider a string that does not contain symbols that differ from Latin 
        /// letters (both registers), digits, dashes or dots.
        /// This methods converts all Cyrillic letters to their Latin equivalent and replaces all 
        /// empty spaces with dashes "-".
        /// This method does not alter the input string.
        /// </summary>
        /// <remarks>
        /// This method replaces with string.Empty <see cref="System.String.Empty"/> all matches
        /// of the following regular expression [^a-zA-z0-9_\.\-]+ .
        /// </remarks>
        /// <returns>Returns a string containing a valid Latin name.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns a copy of this <see cref="T:System.String"/> object. It contains the first charsCount
        /// number of symbols from the current string.
        /// </summary>
        /// <remarks>
        /// If charsCount is a number larger than the length of the current string, this method will 
        /// return the whole string.
        /// </remarks>
        /// <param name="charsCount">The number of characters from the beginning of the current string that will be returned.</param>
        /// <returns>Returns a string - a copy of the first chatsCount number of characters from the current string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns a copy of this <see cref="T:System.String"/> object. It contains the extension of the file (provided
        /// that in the current string a file name with an extension is written).
        /// </summary>
        /// <remarks>It will return string.Empty <see cref="System.String.Empty"/> if the current string is empty
        /// or null or if the current string does not contain an extension</remarks>
        /// <returns>Return a string <see cref="T:System.String"/> containing the extension of a file name.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns a copy of this <see cref="T:System.String"/> object. This method matches the extension of a file
        /// to determine its type
        /// </summary>
        /// <remarks>This method uses the following look-up table to match extensions to type:
        /// "jpg"  ->  "image/jpeg" 
        /// "jpeg" ->  "image/jpeg"
        /// "png"  ->  "image/x-png"
        /// "docx" ->  "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        /// "doc"  ->  "application/msword"
        /// "pdf"  ->  "application/pdf
        /// "txt"  ->  "text/plain"
        /// "rtf"  ->  "application/rtf"
        /// 
        /// This method will return "application/octet-stream" if no match is made!
        /// </remarks>
        /// <returns>Returns a string containing the type of a file corresponding to its extension.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Returns a byte <see cref="T:System.Byte"/> containing the byte representation of a string.
        /// </summary>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
