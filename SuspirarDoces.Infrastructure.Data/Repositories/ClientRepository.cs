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
    public class ClientRepository : IRepository<Cliente>
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int? id)
        {
            return await _context.Clientes.FindAsync(id);
        }
        
        public void Add(Cliente entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Cliente entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Cliente entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
