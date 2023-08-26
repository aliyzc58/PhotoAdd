using Core.Entity;
using System.Linq.Expressions;

namespace Core.Services
{
    public interface IGenericService<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        List<T> GetBy(Expression<Func<T, bool>> expression);
        T Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        void AddRange(List<T> entities);
        void UpdateRange(List<T> entities);
        bool Any(Expression<Func<T, bool>> expression);
        int Count(Expression<Func<T, bool>> expression);
    }
}
