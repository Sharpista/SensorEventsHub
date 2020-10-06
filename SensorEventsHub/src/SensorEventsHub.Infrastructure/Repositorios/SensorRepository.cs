using Microsoft.EntityFrameworkCore;
using SensorEventsHub.Domain.Enitidades;
using SensorEventsHub.Domain.Interfaces.Repositorios;
using SensorEventsHub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorEventsHub.Infrastructure.Repositorios
{
    public class SensorRepository : Repository<Sensor>, ISensorRepository
    {
        public SensorRepository(SensorContext sensorContext) : base(sensorContext)
        {

        }
     
    }
}
