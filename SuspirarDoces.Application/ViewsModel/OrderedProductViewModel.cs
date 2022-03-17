using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class OrderedProductViewModel
    {
        public int IdPedido { get; set; }
        public virtual OrderViewModel Pedido { get; set; }
        public int IdProduto { get; set; }
        public virtual ProductViewModel Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
