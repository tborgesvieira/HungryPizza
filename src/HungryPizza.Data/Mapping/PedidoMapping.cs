using HungryPizza.Domain;
using HungryPizza.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Data.Mapping
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(c => c.CpfLimpo)
                    .IsRequired()
                    .HasMaxLength(Cpf.CpfMaxLength)
                    .HasColumnName("CPF")
                    .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.HasOne(c => c.Usuario)
                .WithMany();

            builder.OwnsOne(c => c.EnderecoEntrega, end =>
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

            builder.HasMany(c => c.Itens)
                .WithOne(c => c.Pedido);

            builder.ToTable("Pedido");
        }
    }
}
