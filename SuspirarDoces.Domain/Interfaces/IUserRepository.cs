using SuspirarDoces.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int? id);
        Task<Usuario> FindUser(Usuario user);
        void Add(Usuario resultado);
        void Update(Usuario resultado);
        void Remove(Usuario resultado);
    }
}
