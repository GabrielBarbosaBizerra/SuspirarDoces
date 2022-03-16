using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Pedido: Base
    {
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        public DateTime DataDoPedido { get; set; }
        public DateTime DataDeEntrega { get; set; }
        public string LocalDeEntrega { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDeEntrada { get; set; }
        public decimal ValorAPagar { get; set; }

        public bool Status { get; set; }

        public virtual List<ProdutoPedido> ProdutosPedidos { get; set; }
        public virtual Entrada Entrada { get; set; }
    }
}
