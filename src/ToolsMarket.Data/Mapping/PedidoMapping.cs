using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.DataVenda)
                   .IsRequired()
                   .HasColumnType("datetime");

            builder.Property(p => p.Quantidade)
                   .IsRequired()
                   .HasColumnType("int");

            builder.Property(p => p.ValorTotal)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasMany(c => c.ItensCarrinho)
                   .WithOne(p => p.Pedido);

            builder.ToTable("Pedidos");
            
        }
    }
}
