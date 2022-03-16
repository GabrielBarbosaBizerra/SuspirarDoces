using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Usuario: Base
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
