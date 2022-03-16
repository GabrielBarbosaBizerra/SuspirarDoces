using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Estoque: Base
    {
        public string Nome { get; set; }
        public int QuantidadeMinima { get; set; }
        public int Quantidade { get; set; }
    }
}
