namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICatalog
    {
        /// <summary>
        /// Addes new content to catalog
        /// </summary>
        void Add(IContent content);

        /// <summary>
        /// Returns a list that contains certain number of matches by title from the catalog
        /// </summary>
        /// <param name="numberOfContentElementsToList">Number of items to be returned</param>
        /// <returns></returns>
        IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList);

        /// <summary>
        /// Changes all occurrence of an URL to a new URL
        /// </summary>
        /// <returns>Return the number of updated items</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
