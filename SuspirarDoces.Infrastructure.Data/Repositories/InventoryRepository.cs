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
    public class InventoryRepository: IRepository<Estoque>
    {
        private readonly DataContext _context;
        public InventoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estoque>> GetAll()
        {
            return await _context.Estoques.AsNoTracking().ToListAsync();
        }

        public async Task<Estoque> GetById(int? id)
        {
            return await _context.Estoques.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Estoque entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(Estoque entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Estoque entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
