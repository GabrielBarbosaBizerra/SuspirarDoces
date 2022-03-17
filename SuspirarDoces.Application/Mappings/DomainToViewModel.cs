using AutoMapper;
using SuspirarDoces.Application.ViewsModel;
using SuspirarDoces.Domain.Entities;

namespace SuspirarDoces.Application.Mappings
{
    public class DomainToViewModel: Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Base, BaseViewModel>();
            CreateMap<Cliente, ClientViewModel>();
            CreateMap<Usuario, UserViewModel>();
            CreateMap<Estoque, InventoryViewModel>();
            CreateMap<Ingrediente, IngredientViewModel>();
            CreateMap<Entrada, FinancialEntryViewModel>();
            CreateMap<Saida, FinancialOutputViewModel>();
            CreateMap<Resultado, FinancialResultViewModel>();
            CreateMap<Pedido, OrderViewModel>();
            CreateMap<ProdutoPedido, OrderedProductViewModel>();
            CreateMap<Produto, ProductViewModel>();
        }
    }
}
