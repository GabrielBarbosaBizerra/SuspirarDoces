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
    public class FinancialOutputRepository: IRepository<Saida>
    {
        private readonly DataContext _context;
        public FinancialOutputRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Saida>> GetAll()
        {
            return await _context.Saidas.ToListAsync();
        }

        public async Task<Saida> GetById(int? id)
        {
            return await _context.Saidas.FindAsync(id);
        }

        public void Add(Saida entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(Saida entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Saida entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
