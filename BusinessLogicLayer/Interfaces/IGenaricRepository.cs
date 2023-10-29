using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IGenaricRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task< T> Get(int id);

        Task<int> Add(T item);

        Task<int> Update(T item);

        Task<int> Delete(T item);
    }
}
