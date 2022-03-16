using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int? id);

        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
