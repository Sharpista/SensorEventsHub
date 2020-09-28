using SensorEventsHub.Domain.Enitidades;
using SensorEventsHub.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SensorEventsHub.Domain.Services
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorService(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }
        public virtual async Task Adicionar(Sensor sensor)
        {
            await _sensorRepository.Adicionar(sensor);
        }

        public virtual async Task Atualizar(Sensor sensor)
        {
             await _sensorRepository.Atualizar(sensor);
        }

        public virtual async Task<IEnumerable<Sensor>> ObterTodos()
        {
            return await _sensorRepository.ObterTodos();
        }
        public virtual async Task<Sensor> BuscarPorId(Guid id)
        {
           return await _sensorRepository.ObterPorId(id);
        }
        public virtual Task<IEnumerable<Sensor>> BuscarPorQualquerParametro(Expression<Func<Sensor, bool>> predicado)
        {
            return null;
            //var pattern = "^[0 - 9] +$";
            //return  _sensorRepository.BuscarPorQualquerParametro(x => x.Valor).Result.Any();
        }

        public void Dispose()
        {
            _sensorRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            await _sensorRepository.Remover(id);
        }

    
    }
}
