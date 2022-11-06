using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    internal class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.NomeCategoria)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.HasMany(p => p.Produtos)
                   .WithOne(c => c.Categoria)
                   .HasForeignKey(c => c.CategoriaId);

            builder.ToTable("Categorias");
        }
    }
}
