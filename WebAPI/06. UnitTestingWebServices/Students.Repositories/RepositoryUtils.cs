using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repositories
{
    public static class RepositoryUtils
    {
        public static T GetOrCreateItem<T>(Func<T, bool> selector,
            Action<T> initializator,
            IRepository repository)
            where T : class, new()
        {
            var items = repository.All<T>();
            var selected = items.Where(selector).FirstOrDefault();
            if (selected == null)
            {
                var newItem = new T();
                initializator(newItem);
                repository.Add(newItem);
                repository.SaveChanges();
                return newItem;
            }

            return selected;
        }
    }
}
