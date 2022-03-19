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
    public class ProductRepository : IRepository<Produto>
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetById(int? id)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        
        public void Add(Produto entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(Produto entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Produto entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
