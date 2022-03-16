using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Domain.Entities
{
    public class Produto: Base
    {
        [ForeignKey("Ingrediente")]
        public int? IdIngrediente { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public virtual List<ProdutoPedido> ProdutosPedidos { get; set; }
    }
}
