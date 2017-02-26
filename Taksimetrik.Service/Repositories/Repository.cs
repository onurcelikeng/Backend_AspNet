using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Taksimetrik.Service.Entities;

namespace Taksimetrik.Service.Repositories
{
    public class Repository<T> : IDisposable where T : class
    {
        private DataContext context;
        private DbSet<T> Table;


        public Repository()
        {
            context = new DataContext();
            Table = context.Set<T>();
        }

        ~Repository()
        {
            Dispose();
        }


        #region Query

        public List<T> All()
        {
            return Table.ToList();
        }

        public List<T> Paging(Func<T, object> orderby, uint PageNumber, int Count)
        {
            return Table.OrderByDescending(orderby).Skip(Convert.ToInt32((PageNumber - 1) * Count)).Take(Count).ToList();
        }

        public List<T> Where(Func<T, bool> where)
        {
            return Table.Where(where).ToList();
        }

        public T First()
        {
            return Table.FirstOrDefault();
        }

        public T First(Func<T, bool> first)
        {
            return Table.FirstOrDefault(first);
        }

        public T Single(Func<T, bool> single)
        {
            return Table.SingleOrDefault(single);
        }

        public int Count()
        {
            return Table.Count();
        }

        #endregion

        #region Proc

        public bool Add(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public bool Update(T entity)
        {
            var entry = context.Entry(entity);
            if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
            {
                entry.State = EntityState.Modified;

                context.Set<T>().Attach(entity);

                context.SaveChanges();
            }

            return Save();
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }

        #endregion

        public DbSet<T> GetTable()
        {
            return Table;
        }

        private bool Save()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(Table);
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}