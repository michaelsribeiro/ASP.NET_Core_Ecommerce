using Dapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToolsMarket.App.ViewModels;

namespace ToolsMarket.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            builder.Ignore<CategoriaViewModel>();
            builder.Ignore<EnderecoViewModel>();
            builder.Ignore<FornecedorViewModel>();
            builder.Ignore<ItemPedidoViewModel>();
            builder.Ignore<PedidoViewModel>();
            builder.Ignore<ProdutoViewModel>();

            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationEntityConfiguration());
        }
    }

    public class ApplicationEntityConfiguration : IEntityTypeConfiguration<ApplicationUserModel>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserModel> builder)
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
        }
    }
}