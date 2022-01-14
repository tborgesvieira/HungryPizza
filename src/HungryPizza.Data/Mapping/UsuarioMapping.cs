﻿using HungryPizza.Domain;
using HungryPizza.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizza.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(c => c.CpfLimpo)
                    .IsRequired()
                    .HasMaxLength(Cpf.CpfMaxLength)
                    .HasColumnName("CPF")
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.OwnsOne(c => c.Endereco, end =>
              {
                  end.Property(c => c.Logradouro)
                    .IsRequired()
                    .HasMaxLength(Endereco.LogradouroMaxLength)
                    .HasColumnName("Logradouro")
                    .HasColumnType($"varchar({Endereco.LogradouroMaxLength})");

                  end.Property(c => c.Numero)
                    .HasColumnName("Numero");

                  end.Property(c => c.Cidade)
                    .IsRequired()
                    .HasMaxLength(Endereco.CidadeMaxLength)
                    .HasColumnName("Cidade")
                    .HasColumnType($"varchar({Endereco.CidadeMaxLength})");

                  end.Property(c => c.Bairro)
                    .IsRequired()
                    .HasMaxLength(Endereco.BairroMaxLength)
                    .HasColumnName("Bairro")
                    .HasColumnType($"varchar({Endereco.BairroMaxLength})");

                  end.Property(c => c.UF)
                    .IsRequired()
                    .HasMaxLength(Endereco.UFMaxLength)
                    .HasColumnName("UF")
                    .HasColumnType($"varchar({Endereco.UFMaxLength})");
              });

            builder.ToTable("Usuario");
        }
    }
}
