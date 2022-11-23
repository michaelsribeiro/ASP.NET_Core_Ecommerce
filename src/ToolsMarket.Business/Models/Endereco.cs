using System;
using ToolsMarket.App.Data;

namespace ToolsMarket.Business.Models
{
    public class Endereco : Entity
    {
        public Endereco(Guid clienteId, string cep, string logradouro, string numero, string bairro, string cidade, string uf, ApplicationUser cliente)
        {
            ClienteId = clienteId;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cliente = cliente;
        }

        public Endereco() { }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        // Relations

        public ApplicationUser? Cliente { get; set; }
        public Guid ClienteId { get; set; }
    }
}
