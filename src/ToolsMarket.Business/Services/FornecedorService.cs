using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutaValidacao(new FornecedorValidation(), fornecedor)) return;
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutaValidacao(new FornecedorValidation(), fornecedor)) return;
        }

        public async Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
