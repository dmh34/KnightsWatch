using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        IEnumerable<T> GetAllEntities();
        T GetByID(int id);

        
    }

    public interface ITaskRepository { }

    public interface IUnitOfWork
    {


    }
}
