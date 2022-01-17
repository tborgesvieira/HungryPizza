﻿// <auto-generated />
using System;
using HungryPizza.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HungryPizza.Data.Migrations
{
    [DbContext(typeof(HungryPizzaContext))]
    [Migration("20220117191127_PedidoData")]
    partial class PedidoData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HungryPizza.Domain.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("ValorPedido")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("HungryPizza.Domain.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Sabor1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Sabor2Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("Sabor1Id");

                    b.HasIndex("Sabor2Id");

                    b.ToTable("PedidoItem", (string)null);
                });

            modelBuilder.Entity("HungryPizza.Domain.Pizza", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("EmFalta")
                        .HasColumnType("bit");

                    b.Property<string>("Sabor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pizza", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("06a3946d-badd-4075-b229-f82074240105"),
                            EmFalta = false,
                            Sabor = "3 Queijos",
                            Valor = 50.0
                        },
                        new
                        {
                            Id = new Guid("f960d8d3-9792-4b46-afcf-5050de19045e"),
                            EmFalta = false,
                            Sabor = "Frango com requeijão",
                            Valor = 59.990000000000002
                        },
                        new
                        {
                            Id = new Guid("9aad79ab-2988-41a5-a4e6-1df0497d2549"),
                            EmFalta = false,
                            Sabor = "Mussarela",
                            Valor = 42.5
                        },
                        new
                        {
                            Id = new Guid("07d81808-2d7d-4d20-a1f5-c1043d9236ff"),
                            EmFalta = false,
                            Sabor = "Pepperoni",
                            Valor = 55.0
                        },
                        new
                        {
                            Id = new Guid("1df80419-7bcd-4748-a41c-d55f17703ed7"),
                            EmFalta = false,
                            Sabor = "Portuguesa",
                            Valor = 45.0
                        },
                        new
                        {
                            Id = new Guid("9f5d722b-6626-4706-986b-aa0cf16375d8"),
                            EmFalta = false,
                            Sabor = "Veggie",
                            Valor = 59.990000000000002
                        });
                });

            modelBuilder.Entity("HungryPizza.Domain.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("HungryPizza.Domain.Pedido", b =>
                {
                    b.HasOne("HungryPizza.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.OwnsOne("HungryPizza.Domain.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("PedidoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CpfLimpo")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("varchar(11)")
                                .HasColumnName("CPF");

                            b1.HasKey("PedidoId");

                            b1.ToTable("Pedido");

                            b1.WithOwner()
                                .HasForeignKey("PedidoId");
                        });

                    b.OwnsOne("HungryPizza.Domain.ValueObjects.Endereco", "EnderecoEntrega", b1 =>
                        {
                            b1.Property<Guid>("PedidoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Logradouro");

                            b1.Property<int?>("Numero")
                                .HasColumnType("int")
                                .HasColumnName("Numero");

                            b1.Property<string>("UF")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)")
                                .HasColumnName("UF");

                            b1.HasKey("PedidoId");

                            b1.ToTable("Pedido");

                            b1.WithOwner()
                                .HasForeignKey("PedidoId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("EnderecoEntrega")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("HungryPizza.Domain.PedidoItem", b =>
                {
                    b.HasOne("HungryPizza.Domain.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HungryPizza.Domain.Pizza", "Sabor1")
                        .WithMany()
                        .HasForeignKey("Sabor1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HungryPizza.Domain.Pizza", "Sabor2")
                        .WithMany()
                        .HasForeignKey("Sabor2Id");

                    b.Navigation("Pedido");

                    b.Navigation("Sabor1");

                    b.Navigation("Sabor2");
                });

            modelBuilder.Entity("HungryPizza.Domain.Usuario", b =>
                {
                    b.OwnsOne("HungryPizza.Domain.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CpfLimpo")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("varchar(11)")
                                .HasColumnName("CPF");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("HungryPizza.Domain.ValueObjects.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Bairro")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Bairro");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Cidade");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Logradouro");

                            b1.Property<int?>("Numero")
                                .HasColumnType("int")
                                .HasColumnName("Numero");

                            b1.Property<string>("UF")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("varchar(2)")
                                .HasColumnName("UF");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("HungryPizza.Domain.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
