using Core.Entity;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System.Linq.Expressions;

namespace Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class 
    {
        protected readonly IGenericRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWok;
        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWok)
        {
            _repository = repository;
            _unitOfWok = unitOfWok;
        }

        public  T Add(T entity)
        {
            _repository.Add(entity);
             _unitOfWok.SaveChanges();
            return entity;

        }

        public void AddRange(List<T> entities)
        {
            _repository.AddRange(entities);
            _unitOfWok.SaveChanges();

        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _repository.Any(expression);
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _repository.Count(expression);
        }

        public void Remove(T entity)
        {
            _repository.Remove(entity);
            _unitOfWok.SaveChanges();

        }

        public void RemoveRange(List<T> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWok.SaveChanges();

        }

        public List<T> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public List<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return _repository.GetBy(expression).ToList();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWok.SaveChanges();

        }

        public void UpdateRange(List<T> entities)
        {
            _repository.UpdateRange(entities);
            _unitOfWok.SaveChanges();

        }
    }
}

