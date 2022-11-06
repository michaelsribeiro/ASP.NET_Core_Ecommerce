using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    public class CarrinhoMapping : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Quantidade)
                   .IsRequired()
                   .HasColumnType("int");

            builder.HasOne(p => p.Pedido)
                   .WithOne(c => c.Carrinho);

            builder.HasMany(p => p.Produtos)
                   .WithOne(c => c.Carrinho)
                   .HasForeignKey(c => c.CarrinhoId);

            builder.ToTable("Carrinhos");
        }
    }
}
