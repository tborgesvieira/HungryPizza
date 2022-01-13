using HungryPizza.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Data.Mapping
{
    public class PizzaMapping : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.Property(c => c.Sabor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.EmFalta)
                .IsRequired();

            builder.ToTable("Pizza");


            builder.HasData(new[]
            {
                new Pizza("3 Queijos", 50),
                new Pizza("Frango com requeijão", 59.99),
                new Pizza("Mussarela", 42.50),
                new Pizza("Pepperoni", 55),
                new Pizza("Portuguesa", 45),
                new Pizza("Veggie", 59.99)
            });
        }
    }
}
