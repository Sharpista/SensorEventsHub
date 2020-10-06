using SensorEventsHub.Domain.Enitidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SensorEventsHub.Domain.Interfaces.Repositorios
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> BuscarPorQualquerParametro(Expression<Func<TEntity, bool>> predicado);
        Task<int> SaveChanges();
    }
}
