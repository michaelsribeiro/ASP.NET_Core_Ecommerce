﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsMarket.Business.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }

        // Relations

        public IEnumerable<Produto>? Produtos { get; set; } = new List<Produto>();
    }
}
