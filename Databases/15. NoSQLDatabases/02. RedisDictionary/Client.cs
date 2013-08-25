namespace _02.RedisDictionary
{
    using System;
    using System.Collections.Generic;

    public class Client
    {
        public static void Main()
        {
            var redisServiceHost = "grouper.redistogo.com";
            var redisServicePort = 9167;
            var redisServicePassword = "0934bf20da3b470458ce09cdf6eab933";

            DictionaryData.EstablishConnection(redisServiceHost, redisServicePort, redisServicePassword);
            // DictionaryData.InserDictionaryEntry("Wine", "Vino");
            var matched = DictionaryData.GetAllDictionaryEntries();
            DisplayWords(matched);
            var beer = DictionaryData.SearchByWord("Beer");
            DisplayWord(beer);
        }


        public static void DisplayWords(IList<KeyValuePair<string, string>> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }

        private static void DisplayWord(KeyValuePair<string, string> word)
        {
            Console.WriteLine("{0} -> {1}", word.Key, word.Value);

        }
    }
}
