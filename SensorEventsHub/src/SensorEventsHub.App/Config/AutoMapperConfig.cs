using AutoMapper;
using SensorEventsHub.App.Data;
using SensorEventsHub.Domain.Enitidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorEventsHub.App.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Sensor, SensorDTO>().ReverseMap();
        }
    }
}
