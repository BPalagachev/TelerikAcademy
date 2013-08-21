namespace FreeContentCatalog
{
    using System;
    using System.Linq;

    public class Content : IComparable, IContent
    {
        private string url;

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ContentInfomation.Title];
            this.Author = commandParams[(int)ContentInfomation.Author];
            this.Size = long.Parse(commandParams[(int)ContentInfomation.Size]);
            this.Url = commandParams[(int)ContentInfomation.Url];
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            Content otherContent = obj as Content;
            if (otherContent == null)
            {
                throw new ArgumentException("Object is not a Content");
            }

            int comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
            return comparisonResul;
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", 
                    this.Type.ToString(), this.Title, this.Author, this.Size, this.Url);

            return output;
        }
    }
}
