using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    internal class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Cnpj)
                   .IsRequired()
                   .HasColumnType("varchar(14)");

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.HasMany(p => p.Produtos)
                   .WithOne(c => c.Fornecedor)
                   .HasForeignKey(c => c.FornecedorId);
        }
    }
}
