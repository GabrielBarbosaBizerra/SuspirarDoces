using AutoMapper;
using SuspirarDoces.Application.ViewsModel;
using SuspirarDoces.Domain.Entities;


namespace SuspirarDoces.Application.Mappings
{
    public class ViewModelToDomain: Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<BaseViewModel, Base>();
            CreateMap<ClientViewModel, Cliente>();
            CreateMap<InventoryViewModel, Estoque>();
            CreateMap<IngredientViewModel, Ingrediente>();
            CreateMap<ProductViewModel, Produto>();
            CreateMap<FinancialEntryViewModel, Entrada>();
            CreateMap<FinancialOutputViewModel, Saida>();
            CreateMap<FinancialResultViewModel, Resultado>();
            CreateMap<OrderViewModel, Pedido>();
            CreateMap<OrderedProductViewModel, ProdutoPedido>();
            CreateMap<UserViewModel, Usuario>();
        }
    }
}
