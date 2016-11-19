using ACStalkMarket.Dtos;
using ACStalkMarket.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACStalkMarket.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domains to DTOs
            CreateMap<People, PeopleDto>();
            CreateMap<Town, TownDto>();
            CreateMap<Week, WeekDto>();
            CreateMap<WeekPattern, WeekPatternDto>();
            CreateMap<WeekValues, WeekValuesDto>();

            // DTOs to Domains
        }
    }
}