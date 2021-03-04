using Data.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Sql.Interfaces
{
    public interface IBaseRepository <T> where T : class, IEntityBase
    {
        void Delete(T entity);
        T GetSingle(int id);
        void Edit(T entity);
        void Add(T item);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetNumOfItemsWithInclude(string propertyName);
        IQueryable<T> GetItemsForParams(int numToTake, int numToSkip);
        bool Commit();
    }
}
