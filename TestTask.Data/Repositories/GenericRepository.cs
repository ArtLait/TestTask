using System.Collections.Generic;
using TestTask.Data.Context;
using TestTask.Data.Models;

namespace TestTask.Data.Repositories
{
    public abstract class GenericRepository<TContext, T> : IRepository<T> 
        where TContext : class
        where T : class
    {
        public GenericRepository(IUnitOfWork<TContext, T> unitOfWork)
        {
            unitOfWork.Register(this);
        }

        public abstract void Create(T item);
        public abstract void Delete(T item);
        public abstract T Get(int id);
        public abstract IEnumerable<T> GetAll();
        public abstract void Update(T item);
    }
}
