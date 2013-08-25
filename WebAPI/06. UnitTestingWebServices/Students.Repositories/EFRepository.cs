using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Students.Repositories
{
    public class EFRepository : IRepository
    {
        public EFRepository(DbContext context)
        {
            this.DbContext = context;
        }

        public DbContext DbContext { get; set; }

        public T Add<T>(T item) where T:class
        {
            var table = this.DbContext.Set<T>();
            DbEntityEntry entry = this.DbContext.Entry<T>(item);

            if (entry.State == System.Data.EntityState.Detached)
            {
                table.Add(item);
            }
            else
            {
                entry.State = System.Data.EntityState.Added;
            }

            return item;
        }

        public T Update<T>(T item) where T : class
        {
            DbEntityEntry entry = this.DbContext.Entry<T>(item);
            var table = this.DbContext.Set<T>();

            if (entry.State == System.Data.EntityState.Detached)
            {
                table.Attach(item);
            }

            entry.State = System.Data.EntityState.Modified;

            return item;
        }

        public T Get<T>(int id) where T : class
        {
            var table = this.DbContext.Set<T>().Find(id);
            return table;
        }

        public void Delete<T>(int id) where T : class
        {
            var item = this.DbContext.Set<T>().Find(id);

            if (item != null)
            {
                this.Delete(item);
            }
        }

        public void Delete<T>(T item) where T : class
        {
            DbEntityEntry entry = this.DbContext.Entry(item);
            var table = this.DbContext.Set<T>();

            if (entry.State != System.Data.EntityState.Deleted)
            {
                entry.State = System.Data.EntityState.Deleted;
            }
            else
            {
                table.Attach(item);
                table.Remove(item);
            }
        }

        public void Attach<N>(N item) where N : class
        {
            var newTable = this.DbContext.Set<N>();
            newTable.Attach(item);
        }

        public void Detach<N>(N item) where N : class
        {
            DbEntityEntry entry = this.DbContext.Entry<N>(item);
            entry.State = System.Data.EntityState.Detached;
        }

        public IQueryable<T> All<T>(params string[] includes) where T : class
        {
            var query = this.DbContext.Set<T>().AsQueryable();

            foreach (var include in includes)
            {
                query = this.DbContext.Set<T>().Include(include);
            }
            return query;
        }

        public IQueryable<T> Find<T>(Expression<Func<T, bool>> predicate, params string[] includes) where T : class
        {
            var found = this.All<T>(includes).Where(predicate);
            return found;
        }

        public void SaveChanges()
        {
            this.DbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }
    }
}