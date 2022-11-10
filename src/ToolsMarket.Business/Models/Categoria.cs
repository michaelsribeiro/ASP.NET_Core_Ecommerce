
namespace ToolsMarket.Business.Models
{
    public class Categoria : Entity
    {
        public Categoria(string nomeCategoria)
        {
            NomeCategoria = nomeCategoria;
        }

        public string NomeCategoria { get; set; }

        // Relations

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
