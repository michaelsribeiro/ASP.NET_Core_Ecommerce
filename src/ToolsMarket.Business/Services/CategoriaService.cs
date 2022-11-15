using ToolsMarket.Business.Interfaces;
using ToolsMarket.Business.Models;
using ToolsMarket.Business.Models.Validations;

namespace ToolsMarket.Business.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository, INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutaValidacao(new CategoriaValidation(), categoria)) return;

            if (_categoriaRepository.Buscar(c => c.NomeCategoria == categoria.NomeCategoria).Result.Any())
            {
                Notificar("Já existe uma categoria com este nome.");
                return;
            }

            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutaValidacao(new CategoriaValidation(), categoria)) return;

            if (_categoriaRepository.Buscar(c => c.NomeCategoria == categoria.NomeCategoria).Result.Any())
            {
                Notificar("Já existe uma categoria com este nome.");
                return;
            }

            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task Remover(Guid id)
        {
            await _categoriaRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaRepository.Dispose();
        }
    }
}
