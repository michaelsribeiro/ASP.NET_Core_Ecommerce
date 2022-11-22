using Microsoft.EntityFrameworkCore;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CustomDbContext db) : base(db) {}

        public async Task<Endereco> ObterEnderecoPorUsuario(Guid usuarioId)
        {
            return await Db.Enderecos.AsNoTracking()
                               .FirstOrDefaultAsync(e => e.Id == usuarioId);
        }

        public async Task<IEnumerable<Endereco>> ObterEnderecos()
        {
            return await Db.Enderecos.AsNoTracking()
                               .OrderBy(c => c.Bairro)
                               .ToListAsync();
        }

        public async Task<Endereco> ObterEnderecoUsuario(Guid id)
        {
            return await Db.Enderecos.AsNoTracking()
                                     .Include(u => u.Cliente)
                                     .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
