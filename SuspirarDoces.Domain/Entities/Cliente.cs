using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Cliente: Base
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public virtual List<Pedido> Pedidos { get; set; }
    }
}
