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
    public class IngredientRepository: IRepository<Ingrediente>
    {
        private readonly DataContext _context;
        public IngredientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingrediente>> GetAll()
        {
            return await _context.Ingredientes.ToListAsync();
        }

        public async Task<Ingrediente> GetById(int? id)
        {
            return await _context.Ingredientes.FindAsync(id);
        }

        public void Add(Ingrediente entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(Ingrediente entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Ingrediente entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
