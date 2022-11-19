﻿using ToolsMarket.Business.Models.Enum;
using ToolsMarket.Business.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolsMarket.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [DisplayName("Descrição")]
        [StringLength(3000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [DisplayName("Marca:")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Valor Unitário")]
        public decimal ValorUnitario { get; set; }
        public string? Imagem { get; set; }

        
        [DisplayName("Imagem")]
        [NotMapped]
        public IFormFile? ImageProduto { get; set; }

        [DisplayName("Disponibilidade:")]
        public StatusProduto? Status { get; set; }

        public decimal? PrecoVenda { get; set; }
        public int QuantidadeParcelas { get; set; } = 6;

        public decimal ValorParcela
        {
            get
            {
                return ValorUnitario / QuantidadeParcelas;
            }
        }

        // Relations

        [NotMapped]
        [DisplayName("Categoria")]
        public CategoriaViewModel? Categoria { get; set; }
        public IEnumerable<CategoriaViewModel> Categorias { get; set; } = new List<CategoriaViewModel>();

        [NotMapped]
        [DisplayName("Fornecedor")]
        public FornecedorViewModel? Fornecedor { get; set; }
        public IEnumerable<FornecedorViewModel>? Fornecedores { get; set; } = new List<FornecedorViewModel>();
    }
}
