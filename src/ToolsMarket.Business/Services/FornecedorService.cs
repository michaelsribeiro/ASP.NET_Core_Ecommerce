using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutaValidacao(new FornecedorValidation(), fornecedor)) return;

            if(_fornecedorRepository.Buscar(f => f.Cnpj == fornecedor.Cnpj).Result.Any())
            {
                Notificar("Já existe um fornecedor com este CNPJ.");
                return;
            }

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutaValidacao(new FornecedorValidation(), fornecedor)) return;

            //if (_fornecedorRepository.Buscar(f => f.Cnpj == fornecedor.Cnpj && f.Id == fornecedor.Id).Result.Any())
            //{
            //    Notificar("Já existe um fornecedor com este CNPJ.");
            //    return;
            //}

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task Remover(Guid id)
        {
            if (_fornecedorRepository.ObterFornecedorProduto(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados.");
                return;
            }

            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
        }
    }
}
