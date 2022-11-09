using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Produto : Entity
    {
        public Guid CategoriaId { get; set; }
        public Guid FornecedorId { get; set; }
        public Guid CarrinhoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Marca { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Imagem { get; set; }
        public StatusProduto Status { get; set; }

        // Relations

        public Categoria? Categoria { get; set; }
        public IEnumerable<Categoria>? Categorias { get; set; } = new List<Categoria>();

        public Fornecedor? Fornecedor { get; set; }
        public IEnumerable<Fornecedor>? Fornecedores { get; set; } = new List<Fornecedor>();

        public Carrinho? Carrinho { get; set; }
    }
}
