using AutoMapper;
using SensorEventsHub.API.Model;
using SensorEventsHub.Domain.Enitidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorEventsHub.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Sensor, SensorDTO>().ReverseMap();
        }
    }
}
