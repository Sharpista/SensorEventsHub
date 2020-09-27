using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorEventsHub.API.Model;
using SensorEventsHub.Domain.Interfaces.Repositorios;

namespace SensorEventsHub.API.Controllers
{
    [Route("api/[controller]")]
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

        // GET: api/Sensor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorDTO>>> GetSensor()
        {
            var sensor = _mapper.Map<IEnumerable<SensorDTO>>(await _sensorService.ObterTodos());

            return Ok(sensor);
        }

        // GET: api/Sensor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorDTO>> GetSensorDTO(Guid id)
        {
            //var sensorDTO =  _mapper.Map<SensorDTO>(await _sensorService.BuscarPorId(id));

            if (sensorDTO == null)
            {
                return NotFound();
            }

            return sensorDTO;
        }

        // PUT: api/Sensor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorDTO(Guid id, SensorDTO sensorDTO)
        {
            if (id != sensorDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sensor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SensorDTO>> PostSensorDTO(SensorDTO sensorDTO)
        {
            _context.SensorDTO.Add(sensorDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorDTO", new { id = sensorDTO.Id }, sensorDTO);
        }

        // DELETE: api/Sensor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensorDTO>> DeleteSensorDTO(Guid id)
        {
            var sensorDTO = await _context.SensorDTO.FindAsync(id);
            if (sensorDTO == null)
            {
                return NotFound();
            }

            _context.SensorDTO.Remove(sensorDTO);
            await _context.SaveChangesAsync();

            return sensorDTO;
        }

        private bool SensorDTOExists(Guid id)
        {
            return _context.SensorDTO.Any(e => e.Id == id);
        }
    }
}
