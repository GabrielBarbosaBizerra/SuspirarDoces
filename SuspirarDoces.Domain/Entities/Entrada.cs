using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Entrada: Base
    {
        [ForeignKey("Pedido")]
        public int? PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
