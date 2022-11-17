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

            builder.ToTable("Carrinhos");
        }
    }
}
