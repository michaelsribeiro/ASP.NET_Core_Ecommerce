using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    internal class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Cep)
                   .IsRequired()
                   .HasColumnType("varchar(8)");

            builder.Property(c => c.Logradouro)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(c => c.Bairro)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Cidade)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Uf)
                   .IsRequired()
                   .HasColumnType("varchar(30)");

            builder.ToTable("Enderecos");
        }
    }
}
