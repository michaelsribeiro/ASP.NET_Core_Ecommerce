using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ToolsMarket.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(builder);
        }
    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
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

            builder.Property(u => u.Imagem)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            // Relação 1:1 Usuário => Endereço
            builder.HasOne(e => e.Endereco)
                   .WithMany(u => u.Usuarios);

            // Relação 1:N Usuário => Pedidos
            builder.HasMany(p => p.Pedido)
                   .WithOne(u => u.Usuario)
                   .HasForeignKey(u => u.UsuarioId);
        }
    }
}