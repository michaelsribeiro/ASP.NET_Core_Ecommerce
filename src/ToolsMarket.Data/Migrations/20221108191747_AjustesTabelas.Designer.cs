﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToolsMarket.Data.Context;

#nullable disable

namespace ToolsMarket.Data.Migrations
{
    [DbContext(typeof(CustomDbContext))]
    [Migration("20221108191747_AjustesTabelas")]
    partial class AjustesTabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToolsMarket.Business.Models.Carrinho", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("Carrinhos", (string)null);
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Enderecos", (string)null);
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Fornecedores", (string)null);
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Frete")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarrinhoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Carrinho", b =>
                {
                    b.HasOne("ToolsMarket.Business.Models.Pedido", "Pedido")
                        .WithOne("Carrinho")
                        .HasForeignKey("ToolsMarket.Business.Models.Carrinho", "PedidoId")
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Categoria", b =>
                {
                    b.HasOne("ToolsMarket.Business.Models.Produto", null)
                        .WithMany("Categorias")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Endereco", b =>
                {
                    b.HasOne("ToolsMarket.Business.Models.Usuario", "Usuario")
                        .WithOne("Endereco")
                        .HasForeignKey("ToolsMarket.Business.Models.Endereco", "UsuarioId")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Fornecedor", b =>
                {
                    b.HasOne("ToolsMarket.Business.Models.Produto", null)
                        .WithMany("Fornecedores")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Pedido", b =>
                {
                    b.HasOne("ToolsMarket.Business.Models.Usuario", "Usuario")
                        .WithMany("Pedido")
                        .HasForeignKey("UsuarioId")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Produto", b =>
                {
                    b.HasOne("ToolsMarket.Business.Models.Carrinho", "Carrinho")
                        .WithMany("Produtos")
                        .HasForeignKey("CarrinhoId")
                        .IsRequired();

                    b.HasOne("ToolsMarket.Business.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.HasOne("ToolsMarket.Business.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Categoria");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Carrinho", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Pedido", b =>
                {
                    b.Navigation("Carrinho")
                        .IsRequired();
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Produto", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Fornecedores");
                });

            modelBuilder.Entity("ToolsMarket.Business.Models.Usuario", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
