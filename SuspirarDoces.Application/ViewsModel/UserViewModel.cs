using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class UserViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "Obrigatório Informar Email")]
        [MinLength(5)]
        [MaxLength(15)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar Senha")]
        [MinLength(4)]
        [MaxLength(8)]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}
