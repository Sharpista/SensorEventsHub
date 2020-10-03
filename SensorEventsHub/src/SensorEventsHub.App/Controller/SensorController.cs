using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SensorEventsHub.App.Data;
using SensorEventsHub.App.Hubs;
using SensorEventsHub.Domain.Enitidades;
using SensorEventsHub.Domain.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensorEventsHub.App.Controller
{
    [Route("api/sensores")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorRepository _sensorRepository;
        private readonly ISensorService _sensorService;
        private readonly IMapper _mapper;
        private IHubContext<EventoHub> _hubContext;

        public SensorController(ISensorRepository sensorRepository,
                                ISensorService sensorService,
                                IMapper mapper,
                                IHubContext<EventoHub> hubContext)
        {
            _sensorRepository = sensorRepository;
            _sensorService = sensorService;
            _mapper = mapper;
            _hubContext = hubContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorDTO>>> ObterTodos()
        {

            var sensor = _mapper.Map<IEnumerable<SensorDTO>>(await _sensorService.ObterTodos());
           
            return Ok(sensor);
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
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", sensor);


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
        [HttpDelete("{id}")]
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

        [HttpGet]
        [Route("nordeste")]
        public async Task<IEnumerable<SensorDTO>> ObterTodosPorRegiaoNordeste()
        {
            var sensor = _mapper.Map<IEnumerable<SensorDTO>>(await _sensorService.BuscarSensoresNordeste());
            return sensor;
        }

        [HttpGet]
        [Route("norte")]
        public async Task<IEnumerable<SensorDTO>> ObterTodosPorRegiaoNorte()
        {
            var sensor = _mapper.Map<IEnumerable<SensorDTO>>(await _sensorService.BuscarSensoresNorte());
            return sensor;
        }

        [HttpGet]
        [Route("sudeste")]
        public async Task<IEnumerable<SensorDTO>> ObterTodosPorRegiaoSudeste()
        {
            var sensor = _mapper.Map<IEnumerable<SensorDTO>>(await _sensorService.BuscarSensoresSudeste());
            return sensor;
        }

        [HttpGet]
        [Route("sul")]
        public async Task<IEnumerable<SensorDTO>> ObterTodosPorRegiaoSul()
        {
            var sensor = _mapper.Map<IEnumerable<SensorDTO>>(await _sensorService.BuscarSensoresSul());
            return sensor;
        }


    }
}
