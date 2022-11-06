using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(u => u.Cpf)
                   .IsRequired()
                   .HasColumnType("varchar(11)");

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(u => u.Imagem)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            // Relação 1:1 Usuário => Endereço
            builder.HasOne(e => e.Endereco)
                   .WithOne(u => u.Usuario);

            // Relação 1:N Usuário => Pedidos
            builder.HasMany(p => p.Pedidos)
                   .WithOne(u => u.Usuario)
                   .HasForeignKey(u => u.UsuarioId);

            builder.ToTable("Usuarios");
        }
    }
}
