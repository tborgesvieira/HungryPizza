using HungryPizza.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizza.Data.Mapping
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.HasKey(c=>c.Id);

            builder.HasOne(c => c.Pedido)
                .WithMany(c => c.Itens);

            builder.HasOne(c => c.Sabor1)
                .WithMany();

            builder.HasOne(c=>c.Sabor2)
                .WithMany();

            builder.ToTable("PedidoItem");
        }
    }
}
