using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Domain;
using UserManagement.Web.Models;

namespace UserManagement.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(x =>
            {
                x.CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country));


                x.CreateMap<User,UserViewModel>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.CityName))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.StateName))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.CountryName));
            });
        }
    }
}