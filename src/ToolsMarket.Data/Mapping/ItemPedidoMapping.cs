using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Quantidade)
                   .IsRequired()
                   .HasColumnType("int");

            builder.Property(p => p.ValorUnitario)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.ToTable("ItensPedido");
        }
    }
}
