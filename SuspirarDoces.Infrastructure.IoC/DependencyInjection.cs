using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuspirarDoces.Application.Interfaces;
using SuspirarDoces.Application.Services;
using SuspirarDoces.Application.ViewsModel;
using SuspirarDoces.Domain.Entities;
using SuspirarDoces.Domain.Interfaces;
using SuspirarDoces.Infrastructure.Data.Context;
using SuspirarDoces.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IRepository<Cliente>, ClientRepository>();
            services.AddScoped<IRepository<Entrada>, FinancialEntryRepository>();
            services.AddScoped<IRepository<Saida>, FinancialOutputRepository>();
            services.AddScoped<IRepository<Resultado>, FinancialResultRepository>();
            services.AddScoped<IRepository<Ingrediente>, IngredientRepository>();
            services.AddScoped<IRepository<Estoque>, InventoryRepository>();
            services.AddScoped<IRepository<Pedido>, OrderRepository>();
            services.AddScoped<IRepository<ProdutoPedido>, OrderedProduct>();
            services.AddScoped<IRepository<Produto>, ProductRepository>();
            services.AddScoped<IRepository<Usuario>, UserRepository>();

            services.AddScoped<IService<ClientViewModel>, ClientService>();
            services.AddScoped<IService<FinancialEntryViewModel>, FinancialEntryService>();
            services.AddScoped<IService<FinancialOutputViewModel>, FinancialOutputService>();
            services.AddScoped<IService<FinancialResultViewModel>, FinancialResultService>();
            services.AddScoped<IService<IngredientViewModel>, IngredientService>();
            services.AddScoped<IService<InventoryViewModel>, InventoryService>();
            services.AddScoped<IService<OrderViewModel>, OrderService>();
            services.AddScoped<IService<OrderedProductViewModel>, OrderedProductService>();
            services.AddScoped<IService<ProductViewModel>, ProductService>();
            services.AddScoped<IService<UserViewModel>,UserService>();

            return services;
        }
    }
}
