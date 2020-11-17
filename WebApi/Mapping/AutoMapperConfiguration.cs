using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ViewModel;
using DAL;

namespace WebApi.AutoMapperConfiguration
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
        }
    }
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<TransportationDTO, Transportation>();
            CreateMap<Transportation, TransportationDTO>();
            CreateMap<Frequency, FrequencyDTO>();
            CreateMap<FrequencyDTO, Frequency>();
            CreateMap<Organinzation, OrganizationDTO>();
            CreateMap<OrganizationDTO, Organinzation>();
            CreateMap<Routes, RoutesDTO>();
            CreateMap<RoutesDTO, Routes>();
            CreateMap<Schedules, SchedulesDTO>();
            CreateMap<SchedulesDTO, Schedules>();
            CreateMap<Station, StationDTO>();
            CreateMap<StationDTO, Station>();
            CreateMap<Track, TrackDTO>();
            CreateMap<TrackDTO, Track>();
            CreateMap<Vehicles, VehiclesDTO>();
            CreateMap<VehiclesDTO, Vehicles>();
        }
    }
}