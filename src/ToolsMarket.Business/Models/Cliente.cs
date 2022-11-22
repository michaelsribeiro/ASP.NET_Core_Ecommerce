using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsMarket.Business.Models.Enum;

namespace ToolsMarket.Business.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string? Imagem { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Endereco Endereco { get; set; }
        public Guid EnderecoId { get; set; }

        public IEnumerable<Pedido>? Pedido { get; set; }
        public Guid? PedidoId { get; set; }

        public Guid ApplicationUserId { get; private set; }
    }
}
