using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            //Valida token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ChaveSecreta"]))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine("Token inválido.: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            Console.WriteLine("Token válido.: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });




            services.AddScoped<IRepository<Cliente>, ClientRepository>();
            services.AddScoped<IFinancialEntryRepository, FinancialEntryRepository>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<IRepository<Saida>, FinancialOutputRepository>();
            services.AddScoped<IFinancialResultRepository, FinancialResultRepository>();
            services.AddScoped<IRepository<Ingrediente>, IngredientRepository>();
            services.AddScoped<IRepository<Estoque>, InventoryRepository>();
            services.AddScoped<IRepository<Pedido>, OrderRepository>();
            services.AddScoped<IRepository<ProdutoPedido>, OrderedProduct>();
            services.AddScoped<IRepository<Produto>, ProductRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IService<ClientViewModel>, ClientService>();
            services.AddScoped<IService<FinancialEntryViewModel>, FinancialEntryService>();
            services.AddScoped<IService<FinancialOutputViewModel>, FinancialOutputService>();
            services.AddScoped<IService<FinancialResultViewModel>, FinancialResultService>();
            services.AddScoped<IService<IngredientViewModel>, IngredientService>();
            services.AddScoped<IService<InventoryViewModel>, InventoryService>();
            services.AddScoped<IService<OrderViewModel>, OrderService>();
            services.AddScoped<IService<OrderedProductViewModel>, OrderedProductService>();
            services.AddScoped<IService<ProductViewModel>, ProductService>();
            services.AddScoped<IService<UserViewModel>, UserService>();

            return services;
        }
    }
}
