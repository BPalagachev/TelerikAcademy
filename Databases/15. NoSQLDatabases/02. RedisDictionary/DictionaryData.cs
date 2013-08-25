namespace _02.RedisDictionary
{
    using System;
    using ServiceStack.Redis;
    using System.Collections.Generic;

    public class DictionaryData
    {
        private static readonly string hashSetId = "words";

        public static string ConnectionString { get; private set; }

        private static RedisClient client;

        public static void SetConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public static void EstablishConnection(string serviceHost, int port, string password)
        {
            client = new RedisClient(serviceHost, port, password);
        }

        public static void InserDictionaryEntry(string word, string traslation)
        {
            client.HSetNX(hashSetId, word.ToAsciiCharArray(), traslation.ToAsciiCharArray());
        }

        public static IList<KeyValuePair<string, string>> GetAllDictionaryEntries()
        {
            var allWords = client.HGetAll(hashSetId);

            IList<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < allWords.Length; i += 2)
            {
                var key = Extensions.StringFromByteArray(allWords[i]);
                var value = Extensions.StringFromByteArray(allWords[i + 1]);
                result.Add(new KeyValuePair<string, string>(key, value));
            }

            return result;
        }


        public static KeyValuePair<string, string> SearchByWord(string word)
        {
            var matched = client.HGet(hashSetId, word.ToAsciiCharArray());
            var value = Extensions.StringFromByteArray(matched);
            return new KeyValuePair<string, string>(word, value);
        }

    }
}
