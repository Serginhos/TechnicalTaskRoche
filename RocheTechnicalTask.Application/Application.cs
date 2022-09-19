using RocheTechnicalTask.Abstractions;
using RocheTechnicalTask.Repository;

namespace RocheTechnicalTask.Application
{
    public interface IApplication<T> : ICrud<T>
    {

    }

    public class Application<T> : IApplication<T>
    {
        IRepository<T> _repository;
        public Application(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }
    }
}