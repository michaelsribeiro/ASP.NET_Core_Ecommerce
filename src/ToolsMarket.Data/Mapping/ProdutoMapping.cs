using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(3000)");

            builder.Property(p => p.Marca)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.Imagem)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Ignore(c => c.Categorias);
            builder.Ignore(c => c.Fornecedores);

            builder.ToTable("Produtos");
        }
    }
}
