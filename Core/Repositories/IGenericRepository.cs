using Core.Entity;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        void AddRange(List<T> entities);
        void UpdateRange(List<T> entities);
        bool Any(Expression<Func<T, bool>> expression);
        int Count(Expression<Func<T, bool>> expression);
    }
}
