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
                x.CreateMap<UserViewModel, User>();
            });
        }
    }
}