using System.Collections.Generic;

namespace Order.Api.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T obj);
        IEnumerable<T> GetAll();
        int SaveChanges();
    }
}