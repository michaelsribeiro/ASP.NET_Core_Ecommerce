using System.Linq.Expressions;
using ToolsMarket.Business.Models;

namespace ToolsMarket.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();

        // Expression está tipada com um tipo delegate Func,
        // que por sua vez está retornando true na comparação
        // caso contenha um Entity que seja igual
        // ao Entity do banco na consulta.
    }
}
