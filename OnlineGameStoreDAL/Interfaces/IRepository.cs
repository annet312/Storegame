using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineGameStoreDAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

       // IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
