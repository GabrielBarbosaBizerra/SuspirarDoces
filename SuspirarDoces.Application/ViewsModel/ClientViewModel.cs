using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class ClientViewModel: BaseViewModel
    {
        [MinLength(11)]
        [MaxLength(11)]
        [DisplayName("CPF do Cliente")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar Nome")]
        [MinLength(3)]
        [MaxLength(23)]
        [DisplayName("Nome do Cliente")]
        public string Nome { get; set; }

        [MinLength(8)]
        [MaxLength(11)]
        [DisplayName("Telefone do Cliente")]
        public string Telefone { get; set; }

        [MinLength(3)]
        [MaxLength(17)]
        [DisplayName("Cidade do Cliente")]
        public string Cidade { get; set; }

        public virtual List<OrderViewModel> Pedidos { get; set; }
    }
}
