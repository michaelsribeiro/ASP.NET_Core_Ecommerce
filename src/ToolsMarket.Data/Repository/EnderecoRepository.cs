using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Data.Context;

namespace ToolsMarket.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(CustomDbContext db) : base(db) {}

        public Task<Endereco> ObterEnderecoPorUsuario(Guid usuarioId)
        {
            return Db.Enderecos.AsNoTracking()
                               .FirstOrDefaultAsync(e => e.Id == usuarioId);
        }
    }
}
