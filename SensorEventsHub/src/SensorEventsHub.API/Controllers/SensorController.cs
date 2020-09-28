using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SensorEventsHub.API.ViewModel;
using SensorEventsHub.Domain.Enitidades;
using SensorEventsHub.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensorEventsHub.API.Controllers
{

    [Route("api/sensores")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorRepository _sensorRepository;
        private readonly ISensorService _sensorService;
        private readonly IMapper _mapper;

        public SensorController(ISensorRepository sensorRepository,
                                ISensorService sensorService,
                                IMapper mapper)
        {
            _sensorRepository = sensorRepository;
            _sensorService = sensorService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IEnumerable<SensorDTO>> ObterTodos()
        {
            var sensor = _mapper.Map<IEnumerable<SensorDTO>>(await _sensorService.ObterTodos());
            return sensor;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SensorDTO>> ObterPorId(Guid id)
        {
            var sensor = await ObterSensorPoId(id);

            if(sensor == null)
            {
                return NotFound();
            }

            return sensor;
        }
        [HttpPost]
        public async Task<ActionResult<SensorDTO>> Adicionar(SensorDTO sensorDTO)
        {
            if(!ModelState.IsValid) return BadRequest();

            var sensor = _mapper.Map<Sensor>(sensorDTO);

            await _sensorService.Adicionar(sensor);

            return Ok(sensor);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SensorDTO>> Atualizar(Guid id, SensorDTO sensorDTO)
        {
            if(id != sensorDTO.Id) return BadRequest();

            if(!ModelState.IsValid) return BadRequest();

            var sensor = _mapper.Map<Sensor>(sensorDTO);

            await _sensorService.Atualizar(sensor);

            return Ok(sensor);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SensorDTO>> Excluir(Guid id)
        {
            var sensor = _mapper.Map<Sensor>(await _sensorService.BuscarPorId(id));

            if(sensor == null) return NotFound();

            await _sensorService.Remover(id);

            return Ok(sensor);
        }
        public async Task<SensorDTO> ObterSensorPoId(Guid id)
        {
            return _mapper.Map<SensorDTO>(await _sensorService.BuscarPorId(id));
        }



    }

}

