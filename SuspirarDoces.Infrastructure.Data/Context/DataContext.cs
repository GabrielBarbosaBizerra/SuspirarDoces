using Microsoft.EntityFrameworkCore;
using SuspirarDoces.Domain.Entities;
using SuspirarDoces.Infrastructure.Data.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuspirarDoces.Infrastructure.Data.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ProdutoPedido> ProdutosPedidos { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Saida> Saidas { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new FinancialEntryConfiguration());
            modelBuilder.ApplyConfiguration(new FinancialOutputConfiguration());
            modelBuilder.ApplyConfiguration(new FinancialResultConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Pedidos)
                .HasForeignKey(p => p.IdCliente);

            modelBuilder.Entity<ProdutoPedido>()
                .HasKey(t => new { t.IdPedido, t.IdProduto });

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pt => pt.Pedido)
                .WithMany(p => p.ProdutosPedidos)
                .HasForeignKey(pt => pt.IdPedido);

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pt => pt.Produto)
                .WithMany(t => t.ProdutosPedidos)
                .HasForeignKey(pt => pt.IdProduto);
        }
    }
}
