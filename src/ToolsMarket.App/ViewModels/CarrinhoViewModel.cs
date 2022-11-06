using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.ViewModels
{
    public class CarrinhoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PedidoId { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }

        // Relations

        public PedidoViewModel? Pedido { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
