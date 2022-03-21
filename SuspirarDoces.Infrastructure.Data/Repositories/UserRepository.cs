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
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> GetById(int? id)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Usuario entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }


        public void Remove(Usuario entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public async Task<Usuario> FindUser(Usuario user)
        {
            return await _context.Usuarios.AsNoTracking().Where(x => x.Email.Equals(user.Email) && x.Senha.Equals(user.Senha)).FirstOrDefaultAsync();
        }
    }
}
