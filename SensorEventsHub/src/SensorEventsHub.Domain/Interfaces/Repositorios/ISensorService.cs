using SensorEventsHub.Domain.Enitidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SensorEventsHub.Domain.Interfaces.Repositorios
{
    public interface ISensorService : IDisposable
    {
        Task Adicionar(Sensor sensor);
        Task Atualizar(Sensor sensor);
        Task Remover(Guid id);
        Task<Sensor> BuscarPorId(Guid id);
        Task<IEnumerable<Sensor>> ObterTodos();
        Task<IEnumerable<Sensor>> BuscarPorQualquerParametro(Expression<Func<Sensor, bool>> predicado);
    }
}
