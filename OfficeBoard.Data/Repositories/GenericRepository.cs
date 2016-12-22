using System;
using System.Data.Entity;
using System.Linq;

namespace OfficeBoard.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected OfficeBoardContext context;
        protected DbSet<T> set;

        public GenericRepository(OfficeBoardContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Detach(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
