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
    public class OrderedProduct: IRepository<ProdutoPedido>
    {
        private readonly DataContext _context;
        public OrderedProduct(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProdutoPedido>> GetAll()
        {
            return await _context.ProdutosPedidos.AsNoTracking().ToListAsync();
        }

        public async Task<ProdutoPedido> GetById(int? id)
        {
            return await _context.ProdutosPedidos.FindAsync(id);
        }

        public void Add(ProdutoPedido entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(ProdutoPedido entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ProdutoPedido entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
