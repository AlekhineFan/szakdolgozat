using DataAccess.Model;
using System;
using System.Linq;

namespace DataAccess.Repositories
{
    public abstract class Repository<T> : IDisposable
        where T : class
    {
        protected QuestionnaireContext DbContext { get; } = new QuestionnaireContext();

        public void SaveChanges() => DbContext.SaveChanges();

        public void Create(T obj)
        {
            DbContext.Set<T>().Add(obj);
            DbContext.SaveChanges();
        }

        public void Update(T obj)
        {
            DbContext.Attach(obj);
            DbContext.SaveChanges();
        }

        public virtual void Delete(T obj)
        {
            DbContext.Remove(obj);
            DbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            if (typeof(SoftDeletable).IsAssignableFrom(typeof(T)))
            {
                return DbContext
                    .Set<T>()
                    .Cast<SoftDeletable>()
                    .Where(x => !x.IsDeleted)
                    .Cast<T>();
            }

            return DbContext.Set<T>();
        }

        public void Dispose() => DbContext?.Dispose();
    }
}