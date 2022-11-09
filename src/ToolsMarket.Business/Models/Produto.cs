using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Produto : Entity
    {
        public Guid CategoriaId { get; set; }
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Imagem { get; set; }
        public StatusProduto Status { get; set; }

        // Relations

        public Categoria Categoria { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }

        public Fornecedor Fornecedor { get; set; }
        public IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}
