using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Enum;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            if (!ExecutaValidacao(new ProdutoValidation(), produto)) return;

            if (_produtoRepository.Buscar(p => p.Nome == produto.Nome).Result.Any())
            {
                Notificar("Já existe um produto com este nome.");
                return;
            }

            await _produtoRepository.Adicionar(produto);
        }

        public async Task Atualizar(Guid id, Guid fornecedor, Guid categoria, string marca, int qtd, string descricao, string? imagem, string nome, decimal? precoVenda, int qtdParcelas,
                                    StatusProduto? status, decimal valorUnitario)    
        {
            var produtoBanco = await _produtoRepository.ObterPorId(id);

            produtoBanco.EditarProduto(id, fornecedor, categoria, marca, qtd, descricao, nome, precoVenda, qtdParcelas, status, valorUnitario);

            if(imagem is not null) produtoBanco.DefinirImagem(imagem);

            if (!ExecutaValidacao(new ProdutoValidation(), produtoBanco)) return;

            await _produtoRepository.Atualizar(produtoBanco);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
