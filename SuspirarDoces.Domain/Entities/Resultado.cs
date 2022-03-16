using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Resultado: Base
    {
        public DateTime Data { get; set; }
        public decimal Entrada { get; set; }
        public decimal Saida { get; set; }
        public decimal ResultadoFinanceiro { get; set; }
    }
}
