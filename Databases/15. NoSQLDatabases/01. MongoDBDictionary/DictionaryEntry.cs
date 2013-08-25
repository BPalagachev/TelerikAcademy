namespace _01.MongoDBDictionary
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class DictionaryEntry
    {
        public BsonObjectId Id { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }
        
        [BsonConstructor]
        public DictionaryEntry(string word, string translation)
        {
            this.Word = word;
            this.Translation = translation;
        }

        public override string ToString()
        {
            string formatted = string.Format("{0} -> {1}", this.Word, this.Translation);
            return formatted;
        }
    }
}
