using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolsMarket.App.Extensions;
using ToolsMarket.App.ViewModels;
using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;

namespace ToolsMarket.App.Controllers
{
    [Authorize]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  ICategoriaRepository categoriaRepository,
                                  IFornecedorRepository fornecedorRepository,
                                  IMapper mapper,
                                  IProdutoService produtoService,
                                  INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _produtoService = produtoService;
        }

        [ClaimsAuthorize("Produto", "Visualizar")]
        [Route("produtos")]
        public async Task<IActionResult> Index()
        {
            var result = await _produtoRepository.ObterTodos();

            foreach(var item in result)
            {
                var fornecedor = await _fornecedorRepository.ObterPorId(item.FornecedorId);

                var categoria = await _categoriaRepository.ObterPorId(item.CategoriaId);

                item.DefinirFornecedor(fornecedor);

                item.DefinirCategoria(categoria);
            }
            
            var viewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(result);

            return View(viewModel);
        }

        [AllowAnonymous]
        [Route("produto/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Adicionar")]
        [Route("novo-produto")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel =  await ObterCategorias(new ProdutoViewModel());

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Adicionar")]
        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]ProdutoViewModel produtoViewModel)
        {
            try
            {
                produtoViewModel = await ObterCategorias(produtoViewModel);

                if (!ModelState.IsValid) return View(produtoViewModel);

                var imgPrefixo = Guid.NewGuid() + "_";

                if (!await UploadArquivo(produtoViewModel.ImageProduto, imgPrefixo))
                {
                    return View(produtoViewModel);
                }

                produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImageProduto.FileName;

                var domain = new Produto(
                    produtoViewModel.CategoriaId,
                    produtoViewModel.FornecedorId,
                    produtoViewModel.Nome,
                    produtoViewModel.Descricao,
                    produtoViewModel.Marca,
                    produtoViewModel.Quantidade,
                    produtoViewModel.ValorUnitario,
                    produtoViewModel.Imagem
                    );

                await _produtoService.Adicionar(domain);

                if (!OperacaoValida()) return View(produtoViewModel);

                TempData["Sucesso"] = "Produto inserido com sucesso";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception err)
            {
                ModelState.AddModelError("erro", err.Message);
                return View(produtoViewModel);
            }
        }

        [ClaimsAuthorize("Produto", "Editar")]
        [Route("editar-produto/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var produto= await ObterCategorias(new ProdutoViewModel());

            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
            produtoViewModel.Categorias = produto.Categorias;
            produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Editar")]
        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [FromForm]ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return NotFound();

            if (produtoViewModel.ImageProduto != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(produtoViewModel.ImageProduto, imgPrefixo))
                {
                    return View(produtoViewModel);
                }

                produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImageProduto.FileName;
            }

            await _produtoService.Atualizar(produtoViewModel.Id, produtoViewModel.FornecedorId, produtoViewModel.CategoriaId,
                                            produtoViewModel.Marca, produtoViewModel.Quantidade, produtoViewModel.Descricao,
                                            produtoViewModel.Imagem, produtoViewModel.Nome, produtoViewModel.PrecoVenda,
                                            produtoViewModel.QuantidadeParcelas, produtoViewModel.Status, produtoViewModel.ValorUnitario);

            if (!OperacaoValida()) return View(produtoViewModel);

            TempData["Sucesso"] = "Produto editado com sucesso";

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Produto", "Excluir")]
        [Route("deletar-produto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProdutoFornecedor(id);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Excluir")]
        [Route("deletar-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterProdutoFornecedor(id);

            if (produtoViewModel != null) await _produtoService.Remover(id);

            if (!OperacaoValida()) return View(produtoViewModel);

            TempData["Sucesso"] = "Produto excluído com sucesso";

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [Route("ferramentas-manuais")]
        public async Task<IActionResult> Manuais()
        {
            var produtosManuais = await ObterProdutosManuais();
            return View(produtosManuais);
        }

        [AllowAnonymous]
        [Route("ferramentas-eletricas")]
        public async Task<IActionResult> Eletricos()
        {
            var produtosEletricos = await ObterProdutosEletricos();
            return View(produtosEletricos);
        }

        [AllowAnonymous]
        [Route("pneumaticas")]
        public async Task<IActionResult> Pneumaticos()
        {
            var produtosPneumaticos = await ObterProdutosPneumaticos();
            return View(produtosPneumaticos);
        }

        [AllowAnonymous]
        [Route("automotivas")]
        public async Task<IActionResult> Automotivos()
        {
            var produtosPneumaticos = await ObterProdutosAutomotivos();
            return View(produtosPneumaticos);
        }

        [AllowAnonymous]
        [Route("acessorios")]
        public async Task<IActionResult> Acessorios()
        {
            var acessorios = await ObterProdutosAcessorios();
            return View(acessorios);
        }

        [AllowAnonymous]
        [Route("casa-e-utilidades")]
        public async Task<IActionResult> Utilidades()
        {
            var utilidades = await ObterProdutosUtilidades();
            return View(utilidades);
        }

        private async Task<ProdutoViewModel> ObterProdutoFornecedor(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedor(id));
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        private async Task<ProdutoViewModel> ObterCategorias(ProdutoViewModel produto)
        {
            produto.Categorias = _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return produto;
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/produtos", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProdutosManuais()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosManuais());
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProdutosEletricos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosEletricos());
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProdutosPneumaticos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosPneumaticos());
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProdutosAutomotivos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosAutomotivos());
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProdutosAcessorios()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosAcessorios());
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProdutosUtilidades()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosUtilidades());
        }
    }
}
