using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsMarket.Business.Models
{
    public class Carrinho : Entity
    {
        public string CarrinhoId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; }

        // Relations
        public Produto Produto { get; set; }
    }
}
