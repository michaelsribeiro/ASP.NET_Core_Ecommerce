using ToolsMarket.Business.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ToolsMarket.Data.Context;
using System.Web.Mvc;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.ViewModels
{
    public class PedidoViewModel
    {
        private readonly CustomDbContext _context;

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Data da Compra")]
        public DateTime DataVenda { get; set; }

        [DisplayName("Frete")]
        public decimal? Frete { get; set; }

        [DisplayName("Status do Pedido")]
        public StatusPedido StatusPedido { get; set; }
        public decimal ValorTotal { get; set; }
        

        // Relations
        public ApplicationUserModel Cliente { get; set; }
        [DisplayName("Cliente")]
        public string ClienteId { get; set; }

        public virtual ICollection<ItemPedidoViewModel> ItensPedido { get; set; }/* = new List<ItemPedidoViewModel>();*/

        //public static PedidoViewModel GetCarrinho(HttpContext context)
        //{
        //    var carrinho = new PedidoViewModel();
        //    carrinho.Id = carrinho.GetCarrinhoId(context);
        //    return carrinho;
        //}

        //public static PedidoViewModel GetCarrinho(Controller controller)
        //{
        //    return GetCarrinho(controller.HttpContext);
        //}

    }
}
