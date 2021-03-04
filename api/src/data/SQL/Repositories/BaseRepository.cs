using Data.Sql.EF;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Sql.Interfaces
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntityBase
    {
        private readonly ForecasterContext _context;
        public BaseRepository(ForecasterContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetItemsForParams(int numToTake, int numToSkip)
        {
            return _context.Set<T>().Skip(numToSkip).Take(numToTake);
        }

        public IQueryable<T> GetNumOfItemsWithInclude(string propertyName)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
