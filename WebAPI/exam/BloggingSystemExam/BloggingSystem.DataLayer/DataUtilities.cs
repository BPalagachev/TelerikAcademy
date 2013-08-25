using System;
using System.Data.Entity;
using System.Linq;

namespace BloggingSystem.DataLayer
{
    public static class DataUtilities
    {
        public static T GetOrCreateItem<T>(Func<T, bool> selector, Action<T> initializator, DbContext db)
           where T : class, new()
        {
            var items = db.Set<T>();
            var selected = items.Where(selector).FirstOrDefault();
            if (selected == null)
            {
                var newItem = new T();
                initializator(newItem);
                items.Add(newItem);
                db.SaveChanges();
                return newItem;
            }

            return selected;
        }
    }
}
