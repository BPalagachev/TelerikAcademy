namespace _07.TextToXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Masks a text file as a IEnumerable collection.
    /// </summary>
    public class TextFileLineEnumerator : IEnumerable<string>
    {
        private string path;

        public TextFileLineEnumerator(string pathToTextFile)
        {
            this.path = pathToTextFile;
        }
        
        public IEnumerator<string> GetEnumerator()
        {
            StreamReader textFileReader = new StreamReader(this.path);
            using (textFileReader)
            {
                string currentLine = textFileReader.ReadLine();
                while (currentLine != null)
                {
                    yield return currentLine;
                    currentLine = textFileReader.ReadLine();
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
