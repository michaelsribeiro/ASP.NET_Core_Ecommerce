using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CustomDbContext db) : base(db)
        {
        }

        public async Task<Usuario> ObterUsuarioEndereco(Guid id)
        {
            return await Db.Usuarios.AsNoTracking()
                                    .Include(e => e.Endereco)
                                    .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> ObterUsuarioPedido(Guid id)
        {
            return await Db.Usuarios.AsNoTracking()
                                    .Include(e => e.Pedido)
                                    .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarioPedidos()
        {
            return await Db.Usuarios.AsNoTracking()
                                    .Include(e => e.Pedido)
                                    .ToListAsync();
        }
    }
}
