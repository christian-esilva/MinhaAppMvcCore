﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhaApp.Infraestrutura.Contexto;

namespace MinhaApp.Infraestrutura.Migrations
{
    [DbContext(typeof(ContextoApp))]
    [Migration("20191010154124_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MinhaApp.Negocios.Entidades.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("IdFornecedor");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("MinhaApp.Negocios.Entidades.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("TipoFornecedor");

                    b.HasKey("Id");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("MinhaApp.Negocios.Entidades.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("IdFornecedor");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("MinhaApp.Negocios.Entidades.Endereco", b =>
                {
                    b.HasOne("MinhaApp.Negocios.Entidades.Fornecedor", "Fornecedor")
                        .WithOne("Endereco")
                        .HasForeignKey("MinhaApp.Negocios.Entidades.Endereco", "IdFornecedor");
                });

            modelBuilder.Entity("MinhaApp.Negocios.Entidades.Produto", b =>
                {
                    b.HasOne("MinhaApp.Negocios.Entidades.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("IdFornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}
