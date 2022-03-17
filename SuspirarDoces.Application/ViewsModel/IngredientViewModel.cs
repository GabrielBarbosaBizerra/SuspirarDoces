using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class IngredientViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "Obrigatório informar a Quantidade de Ovos")]
        [Range(1, 99)]
        [DisplayName("Quantidade de Ovos")]
        public int QuantidadeOvos { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Quantidade de Açúcar")]
        [Range(1, 999)]
        [DisplayName("Quantidade Açúcar")]
        public int QuantidadeAcucar { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Quantidade de Glaçúcar")]
        [Range(1, 999)]
        [DisplayName("Quantidade de Glaçúcar")]
        public int QuantidadeGlacucar { get; set; }
    }
}
