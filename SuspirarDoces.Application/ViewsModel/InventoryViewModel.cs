using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class InventoryViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "Obrigatório Informar Nome")]
        [MinLength(3)]
        [MaxLength(12)]
        [DisplayName("Nome do Estoque")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Quantidade Mínima")]
        [Range(1, 50)]
        [DisplayName("Quantidade Mínima de Estoque")]
        public int QuantidadeMinima { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Quantidade")]
        [Range(1, 99)]
        [DisplayName("Quantidade de Estoque")]
        public int Quantidade { get; set; }
    }
}
