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
    public class OrderRepository: IRepository<Pedido>
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await _context.Pedidos.AsNoTracking()
                                         .Include(x => x.ProdutosPedidos)
                                         .ThenInclude(e => e.Produto)
                                         .Include(c => c.Cliente)
                                         .ToListAsync();
        }

        public async Task<Pedido> GetById(int? id)
        {
            return await _context.Pedidos
                                 .AsNoTracking()
                                 .Include(x => x.ProdutosPedidos)
                                 .ThenInclude(e => e.Produto)
                                 .Include(c => c.Cliente)
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Pedido entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(Pedido entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Pedido entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
