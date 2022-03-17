using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class FinancialEntryViewModel: BaseViewModel
    {
        public int? PedidoId { get; set; }
        public virtual OrderViewModel Pedido { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar Nome")]
        [MinLength(3)]
        [MaxLength(20)]
        [DisplayName("Nome da Entrada")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Valor")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor da Entrada")]
        public decimal Valor { get; set; }

        [MinLength(3)]
        [MaxLength(25)]
        [DisplayName("Descrição da Entrada")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a Data")]
        [Display(Name = "Data da Entrada")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime Data { get; set; }
    }
}
