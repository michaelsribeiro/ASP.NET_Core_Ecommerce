using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
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

            builder.Property(p => p.SubTotal)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.ProdutoId)
                    .IsRequired();

            builder.Property(c => c.PedidoId)
                    .IsRequired();

            builder.HasOne(p => p.Produto)
                   .WithMany()
                   .HasForeignKey(p => p.ProdutoId);                   

            builder.ToTable("ItensPedido");
        }
    }
}
