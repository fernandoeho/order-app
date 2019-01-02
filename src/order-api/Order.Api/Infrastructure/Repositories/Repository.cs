using System.Collections.Generic;
using System.Linq;

namespace Order.Api.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected OrderContext _context;

        public Repository(OrderContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}