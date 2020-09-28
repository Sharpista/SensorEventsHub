﻿using AutoMapper;
using SensorEventsHub.API.ViewModel;
using SensorEventsHub.Domain.Enitidades;


namespace SensorEventsHub.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Sensor, SensorDTO>().ReverseMap();
        }

    }
}