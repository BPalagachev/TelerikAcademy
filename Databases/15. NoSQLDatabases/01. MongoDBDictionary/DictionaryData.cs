namespace _01.MongoDBDictionary
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;

    public class DictionaryData
    {
        private static readonly string dbName = "dictionary";

        private static string connectionString;
        private static MongoClient client;
        private static MongoServer server;
        private static MongoDatabase database;
        private static MongoCollection<DictionaryEntry> entries;

        public static void SetConnectionString(string str)
        {
            connectionString = str;
        }

        public static void EstablishConnection()
        {
            client = new MongoClient(connectionString);
            server = client.GetServer();
            database = server.GetDatabase(dbName);
            entries = database.GetCollection<DictionaryEntry>("Entries");
        }

        public static IList<DictionaryEntry> GetAllDictionaryEntries()
        {
            return ToList(entries.FindAllAs<DictionaryEntry>());
        }

        public static void InsertDictionaryEntry(DictionaryEntry newEntry)
        {
            entries.Insert<DictionaryEntry>(newEntry);
        }

        public static IList<DictionaryEntry> SearchByWord(string word)
        {
            var query = Query.EQ("Word", word);
            var matched = entries.FindAs<DictionaryEntry>(query);
            return ToList(matched);
        }
        
        private static IList<DictionaryEntry> ToList(MongoCursor<DictionaryEntry> cursor)
        {
            List<DictionaryEntry> resultAsList = new List<DictionaryEntry>();

            foreach (var item in cursor)
            {
                resultAsList.Add(item);                
            }

            return resultAsList;
        }
    }
}
