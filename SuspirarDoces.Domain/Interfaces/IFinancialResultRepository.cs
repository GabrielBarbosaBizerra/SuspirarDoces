using SuspirarDoces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Interfaces
{
    public interface IFinancialResultRepository
    {
        Task<IEnumerable<Resultado>> GetAll();
        Task<Resultado> GetById(int? id);
        Task<Resultado> GetByDate(int day, int month);
        void Add(Resultado resultado);
        void Update(Resultado resultado);
        void Remove(Resultado resultado);
    }
}
