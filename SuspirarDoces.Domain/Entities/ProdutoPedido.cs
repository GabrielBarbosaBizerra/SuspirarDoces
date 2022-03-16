using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class ProdutoPedido
    {
        public int IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
