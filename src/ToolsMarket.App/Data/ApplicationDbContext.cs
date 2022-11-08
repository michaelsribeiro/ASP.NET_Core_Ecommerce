using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToolsMarket.App.ViewModels;

namespace ToolsMarket.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ToolsMarket.App.ViewModels.CarrinhoViewModel> CarrinhoViewModel { get; set; }
        public DbSet<ToolsMarket.App.ViewModels.FornecedorViewModel> FornecedorViewModel { get; set; }
        public DbSet<ToolsMarket.App.ViewModels.PedidoViewModel> PedidoViewModel { get; set; }
    }
}