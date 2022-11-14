using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public async Task Adicionar(Produto produto)
        {
            if (!ExecutaValidacao(new ProdutoValidation(), produto)) return;
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutaValidacao(new ProdutoValidation(), produto)) return;
        }

        public async Task Remover(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
