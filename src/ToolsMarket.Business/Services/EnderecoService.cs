using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository, INotificador notificador) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Endereco endereco)
        {
            if (!ExecutaValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Adicionar(endereco);
        }

        public async Task Atualizar(Endereco endereco)
        {
            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            await _enderecoRepository.Remover(id);
        }

        public void Dispose()
        {
            _enderecoRepository?.Dispose();
        }
    }
}
