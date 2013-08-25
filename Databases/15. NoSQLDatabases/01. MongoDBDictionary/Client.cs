namespace _01.MongoDBDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Client
    {
        public static void Main()
        {
            DictionaryData.SetConnectionString("mongodb://admin:a13131313@ds035368.mongolab.com:35368/dictionary");
            DictionaryData.EstablishConnection();

            // DictionaryData.InsertDictionaryEntry(new DictionaryEntry("Wine", "Вино"));
            // var words = DictionaryData.GetAllDictionaryEntries();
            var words = DictionaryData.SearchByWord("Beer");
            DisplayResults(words);
        }

        public static void DisplayResults(IList<DictionaryEntry> resultCollection)
        {
            foreach (var item in resultCollection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
