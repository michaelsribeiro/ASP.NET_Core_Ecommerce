
namespace ToolsMarket.Business.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; }

        // Relations

        public IEnumerable<Produto>? Produtos { get; set; } = new List<Produto>();
    }
}
