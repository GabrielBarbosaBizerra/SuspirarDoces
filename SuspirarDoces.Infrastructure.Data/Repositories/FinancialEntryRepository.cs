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
    public class FinancialEntryRepository: IRepository<Entrada>
    {
        private readonly DataContext _context;
        public FinancialEntryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entrada>> GetAll()
        {
            return await _context.Entradas.AsNoTracking().ToListAsync();
        }

        public async Task<Entrada> GetById(int? id)
        {
            return await _context.Entradas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Entrada entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(Entrada entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Entrada entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
