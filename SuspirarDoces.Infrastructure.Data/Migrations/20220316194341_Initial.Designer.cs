﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SuspirarDoces.Infrastructure.Data.Context;

namespace SuspirarDoces.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220316194341_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CPF")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("Cidade")
                        .HasMaxLength(17)
                        .HasColumnType("character varying(17)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(23)
                        .HasColumnType("character varying(23)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeMinima")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("QuantidadeAcucar")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeGlacucar")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeOvos")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Ingredientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuantidadeAcucar = 350,
                            QuantidadeGlacucar = 150,
                            QuantidadeOvos = 4
                        });
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataDeEntrega")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataDoPedido")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<string>("LocalDeEntrega")
                        .HasMaxLength(22)
                        .HasColumnType("character varying(22)");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<decimal>("ValorAPagar")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("ValorDeEntrada")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int?>("IdIngrediente")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(22)
                        .HasColumnType("character varying(22)");

                    b.Property<decimal>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdIngrediente");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.ProdutoPedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .HasColumnType("integer");

                    b.Property<int>("IdProduto")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("IdPedido", "IdProduto");

                    b.HasIndex("IdProduto");

                    b.ToTable("ProdutosPedidos");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Resultado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Entrada")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("ResultadoFinanceiro")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.Property<decimal>("Saida")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Resultados");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Saida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Saidas");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Entrada", b =>
                {
                    b.HasOne("SuspirarDoces.Domain.Entities.Pedido", "Pedido")
                        .WithOne("Entrada")
                        .HasForeignKey("SuspirarDoces.Domain.Entities.Entrada", "PedidoId");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("SuspirarDoces.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Produto", b =>
                {
                    b.HasOne("SuspirarDoces.Domain.Entities.Ingrediente", "Ingrediente")
                        .WithMany()
                        .HasForeignKey("IdIngrediente");

                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.ProdutoPedido", b =>
                {
                    b.HasOne("SuspirarDoces.Domain.Entities.Pedido", "Pedido")
                        .WithMany("ProdutosPedidos")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SuspirarDoces.Domain.Entities.Produto", "Produto")
                        .WithMany("ProdutosPedidos")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Entrada");

                    b.Navigation("ProdutosPedidos");
                });

            modelBuilder.Entity("SuspirarDoces.Domain.Entities.Produto", b =>
                {
                    b.Navigation("ProdutosPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
