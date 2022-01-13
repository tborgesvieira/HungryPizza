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
    [Migration("20220113104910_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                            Id = new Guid("ef7a10e5-a555-4dbd-8f85-645bbeba2622"),
                            EmFalta = false,
                            Sabor = "3 Queijos",
                            Valor = 50.0
                        },
                        new
                        {
                            Id = new Guid("6ee1dade-601b-4ec8-8049-0224bf4849ca"),
                            EmFalta = false,
                            Sabor = "Frango com requeijão",
                            Valor = 59.990000000000002
                        },
                        new
                        {
                            Id = new Guid("71d8d319-0e39-4653-84c8-8503fe4764c1"),
                            EmFalta = false,
                            Sabor = "Mussarela",
                            Valor = 42.5
                        },
                        new
                        {
                            Id = new Guid("2325ce60-fb02-40e7-bac9-713dd83304c7"),
                            EmFalta = false,
                            Sabor = "Pepperoni",
                            Valor = 55.0
                        },
                        new
                        {
                            Id = new Guid("0d4a9024-d786-4434-a79c-4ae638d044d7"),
                            EmFalta = false,
                            Sabor = "Portuguesa",
                            Valor = 45.0
                        },
                        new
                        {
                            Id = new Guid("90f90cba-a884-45cb-98f7-b564087fc1d1"),
                            EmFalta = false,
                            Sabor = "Veggie",
                            Valor = 59.990000000000002
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
