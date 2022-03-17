using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class ProductViewModel: BaseViewModel
    {
        public int? IdIngrediente { get; set; }
        public virtual IngredientViewModel Ingrediente { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar Nome")]
        [MinLength(3)]
        [MaxLength(22)]
        [DisplayName("Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Preço")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Preço do Produto")]
        public decimal Preco { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [DisplayName("Descrição do Produto")]
        public string Descricao { get; set; }
        public virtual List<OrderedProductViewModel> ProdutosPedidos { get; set; }
    }
}
