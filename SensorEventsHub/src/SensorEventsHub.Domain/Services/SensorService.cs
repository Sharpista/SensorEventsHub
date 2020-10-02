using SensorEventsHub.Domain.Enitidades;
using SensorEventsHub.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
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
            var newSensor = new Sensor
            {
                Timestamp = ConverterUnix(sensor.Timestamp),
                Tag = sensor.Tag,
                Valor = sensor.Valor
            };
                         
            await _sensorRepository.Adicionar(newSensor);
        }

        public virtual async Task Atualizar(Sensor sensor)
        {
            await _sensorRepository.Atualizar(sensor);
        }

        public async Task Remover(Guid id)
        {
            await _sensorRepository.Remover(id);
        }

        public virtual async Task<IEnumerable<Sensor>> ObterTodos()
        {
            return await _sensorRepository.ObterTodos();
        }
        public virtual async Task<Sensor> BuscarPorId(Guid id)
        {
            return await _sensorRepository.ObterPorId(id);
        }
        public virtual Task<IEnumerable<Sensor>> BuscarSensoresNordeste()
        {
            return _sensorRepository.BuscarPorQualquerParametro(x => !string.IsNullOrEmpty(x.Valor) && x.Tag.Contains("nordeste"));
        }

        public Task<IEnumerable<Sensor>> BuscarSensoresSul()
        {
            return _sensorRepository.BuscarPorQualquerParametro(x => !string.IsNullOrEmpty(x.Valor) && x.Tag.Contains("sul"));
        }

        public Task<IEnumerable<Sensor>> BuscarSensoresNorte()
        {
            return _sensorRepository.BuscarPorQualquerParametro(x => !string.IsNullOrEmpty(x.Valor) && x.Tag.Contains("norte"));
        }

        public Task<IEnumerable<Sensor>> BuscarSensoresSudeste()
        {
            return _sensorRepository.BuscarPorQualquerParametro( x => x.Tag.Contains("sudeste"));
        }

        public void Dispose()
        {
            _sensorRepository?.Dispose();
        }
        public string ConverterUnix(string data)
        {
            var timeSpan = (DateTime.Parse(data) - new DateTime(1970, 1, 1, 0, 0, 0));
            var unix = Convert.ToString(timeSpan.TotalSeconds);
            return unix;
        }


    }



}
