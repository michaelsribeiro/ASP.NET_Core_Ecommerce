
namespace ToolsMarket.Business.Models
{
    public class Categoria : Entity
    {
        public string NomeCategoria { get; set; }

        // Relations

        public IEnumerable<Produto>? Produtos { get; set; } = new List<Produto>();
    }
}
