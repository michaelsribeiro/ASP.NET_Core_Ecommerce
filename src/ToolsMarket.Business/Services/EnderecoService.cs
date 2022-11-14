using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {
        public async Task Adicionar(Endereco endereco)
        {
            if (!ExecutaValidacao(new EnderecoValidation(), endereco)) return;
        }

        public async Task Atualizar(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
