using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface ICategoriaService : IDisposable
    {
        Task Adicionar(Categoria categoria);
        Task Atualizar(Categoria categoria);
        Task Remover(Guid id);
    }
}
