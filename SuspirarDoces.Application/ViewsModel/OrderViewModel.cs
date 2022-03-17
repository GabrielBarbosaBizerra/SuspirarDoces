using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Application.ViewsModel
{
    public class OrderViewModel: BaseViewModel
    {
        public int IdCliente { get; set; }
        public virtual ClientViewModel Cliente { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a Data")]
        [DisplayName("Data do Pedido")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataDoPedido { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar a Data")]
        [DisplayName("Data de Entrega")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime DataDeEntrega { get; set; }

        [MinLength(3)]
        [MaxLength(22)]
        [DisplayName("Local de Entrega")]
        public string LocalDeEntrega { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Valor")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor Total do Pedido")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Valor")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor de Entrada do Pedido")]
        public decimal ValorDeEntrada { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Valor")]
        [Range(1, 99999.99)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Valor a Pagar do Pedido")]
        public decimal ValorAPagar { get; set; }

        [DisplayName("Status do Pedido")]
        public bool Status { get; set; }

        public virtual List<OrderedProductViewModel> ProdutosPedidos { get; set; }
        public virtual FinancialEntryViewModel Entrada { get; set; }
    }
}
