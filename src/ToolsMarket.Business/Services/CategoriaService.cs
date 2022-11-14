using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutaValidacao(new CategoriaValidation(), categoria)) return;
        }

        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutaValidacao(new CategoriaValidation(), categoria)) return;
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
