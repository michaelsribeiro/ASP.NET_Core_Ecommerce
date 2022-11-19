using System;
using ToolsMarket.App.Data;

namespace ToolsMarket.Business.Models
{
    public class Endereco : Entity
    {
        public Endereco(Guid usuarioId, string cep, string logradouro, string bairro, string cidade, string uf)
        {
            UsuarioId = usuarioId;
            Cep = cep;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }

        public Guid UsuarioId { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        // Relations
        public IEnumerable<ApplicationUser> Usuarios { get; set; }
    }
}
