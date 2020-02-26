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

        //TODO: Delete

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public void Dispose() => DbContext?.Dispose();
    }
}