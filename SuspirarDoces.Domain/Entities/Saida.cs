using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Saida: Base
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
