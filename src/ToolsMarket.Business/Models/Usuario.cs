namespace ToolsMarket.Business.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Genero { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string? Imagem { get; set; }

        // Relations
        public Endereco Endereco { get; set; }
        public IEnumerable<Pedido>? Pedidos { get; set; } = new List<Pedido>();
    }
}