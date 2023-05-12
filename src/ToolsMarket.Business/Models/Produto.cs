using System.ComponentModel.DataAnnotations.Schema;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Produto : Entity
    {
        public Guid CategoriaId { get; private set; }
        public Guid FornecedorId { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public string Marca { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public string? Imagem { get; private set; }
        public StatusProduto Status { get; private set; }
        public Categoria Categoria { get; private set; }
        public IEnumerable<Categoria>? Categorias { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
        public IEnumerable<Fornecedor>? Fornecedores { get; private set; }

        public Produto() { }

        public Produto(Guid categoriaId, Guid fornecedorId, string nome, string? descricao, string marca, int quantidade, decimal valorUnitario, string? imagem)
        {
            CategoriaId = categoriaId;
            FornecedorId = fornecedorId;
            Nome = nome;
            Descricao = descricao;
            Marca = marca;
            DefinirQuantidade(quantidade);
            ValorUnitario = valorUnitario;
            Imagem = imagem;
            DefinirStatus(quantidade);
        }

        public void DefinirQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new Exception("Nãó é possível adicionar valor menor ou igual a zero");

            Quantidade = quantidade;
        }

        public void DefinirStatus(int quantidade)
        {
            Status = (quantidade > 0) ? StatusProduto.Imediata : StatusProduto.Indisponível;
        }


        public void EditarProduto(Guid id, Guid fornecedor, Guid categoria, string marca, int qtd, string descricao, string nome, decimal? precoVenda, int qtdParcelas,
                                  StatusProduto? status, decimal valorUnitario)
        {
            CategoriaId = categoria;
            FornecedorId = fornecedor;
            Nome = nome;
            Descricao = descricao;
            Marca = marca;
            DefinirQuantidade(qtd);
            ValorUnitario = valorUnitario;
            DefinirStatus(qtd);
        }

        public void DefinirImagem(string imagem)
        {
            Imagem = imagem;
        }

        public void DefinirFornecedor(Fornecedor fornecedor)
        {
            Fornecedor = fornecedor;
        }

        public void DefinirCategoria(Categoria categoria)
        {
            Categoria = categoria;
        }
    }
}
