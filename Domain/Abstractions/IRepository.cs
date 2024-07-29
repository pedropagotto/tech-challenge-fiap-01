using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IRepository<T> where T : EntityBase
    {
        IList<T> ListAll();
        T? GetById(int id);
        void Create(T entidade);
        void Update(T entidade);
        void Delete(int id);
    }
}
