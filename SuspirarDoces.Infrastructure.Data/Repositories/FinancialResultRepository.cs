using Microsoft.EntityFrameworkCore;
using SuspirarDoces.Domain.Entities;
using SuspirarDoces.Domain.Interfaces;
using SuspirarDoces.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Infrastructure.Data.Repositories
{
    public class FinancialResultRepository: IRepository<Resultado>
    {
        private readonly DataContext _context;
        public FinancialResultRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resultado>> GetAll()
        {
            return await _context.Resultados.AsNoTracking().ToListAsync();
        }

        public async Task<Resultado> GetById(int? id)
        {
            return await _context.Resultados.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Resultado entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(Resultado entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Resultado entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
