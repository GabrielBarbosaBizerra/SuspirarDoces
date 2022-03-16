using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Ingrediente: Base
    {
        public int QuantidadeOvos { get; set; }
        public int QuantidadeAcucar { get; set; }
        public int QuantidadeGlacucar { get; set; }
    }
}
