using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.App.Data;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(u => u.Cpf)
                   .IsRequired()
                   .HasColumnType("varchar(11)");

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.EnderecoId)
                   .IsRequired();

            builder.HasOne(e => e.Endereco)
                   .WithMany()
                   .HasForeignKey(e => e.EnderecoId);

            // Relação 1:N Usuário => Pedidos
            builder.HasMany(p => p.Pedido)
                   .WithOne(u => u.Cliente)
                   .HasForeignKey(u => u.ClienteId);
        }
    }
}
