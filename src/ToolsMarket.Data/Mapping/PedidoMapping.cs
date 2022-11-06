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

            builder.Property(p => p.NomeCliente)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Quantidade)
                   .IsRequired()
                   .HasColumnType("int");

            builder.HasMany(c => c.Carrinhos)
                   .WithOne(p => p.Pedido)
                   .HasForeignKey(p => p.PedidoId);

            builder.ToTable("Pedidos");
            
        }
    }
}
