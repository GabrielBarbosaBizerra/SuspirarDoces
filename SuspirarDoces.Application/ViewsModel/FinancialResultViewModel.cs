using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class FinancialResultViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "Obrigatório Informar a Data")]
        [Display(Name = "Data do Resultado")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Valor")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor de Entrada")]
        public decimal Entrada { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Valor")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor de Saída")]
        public decimal Saida { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Valor")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor do Resultado")]
        public decimal ResultadoFinanceiro { get; set; }
    }
}
