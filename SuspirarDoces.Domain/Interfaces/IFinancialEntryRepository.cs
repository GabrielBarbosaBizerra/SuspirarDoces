using SuspirarDoces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Interfaces
{
    public interface IFinancialEntryRepository
    {
        Task<IEnumerable<Entrada>> GetAll();
        Task<Entrada> GetById(int? id);
        Task<Entrada> GetByOrderId(int? id);

        void Add(Entrada entry);
        void Update(Entrada entry);
        void Remove(Entrada entry);
    }
}
