using System;

namespace ToolsMarket.Business.Models
{
    public class Endereco : Entity
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int MyProperty { get; set; }

        // Relations
        public Usuario Usuario { get; set; }
    }
}
