using System;
using System.Linq;
using System.Linq.Expressions;

namespace Students.Repositories
{
    public interface IRepository : IDisposable
    {
        T Add<T>(T item) where T : class;
        T Update<T>(T item) where T : class;
        T Get<T>(int id) where T : class;
        void Delete<T>(int id) where T : class;
        void Delete<T>(T item) where T : class;
        void Attach<N>(N item) where N : class;
        void Detach<N>(N item) where N : class;
        void SaveChanges();
        IQueryable<T> All<T>(params string[] includes) where T : class;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate, params string[] includes) where T : class;
    }
}
