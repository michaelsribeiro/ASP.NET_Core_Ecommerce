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

            builder.HasOne(c => c.Carrinho)
                   .WithOne(p => p.Pedido);

            builder.ToTable("Pedidos");
            
        }
    }
}
