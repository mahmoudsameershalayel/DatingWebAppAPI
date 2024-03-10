using App.Core.APIDto.ApplicationUserDto;
using App.Core.APIViewModel;
using App.Data.DbEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.API.Infrastructure.AutoMapper
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()             
        {
            CreateMap<User , ApplicationUserViewModel>().ReverseMap();
            CreateMap<User,CreateApplicationUserDto>().ReverseMap();
            CreateMap<User, UpdateApplicationUserDto>().ReverseMap();

        }
    }
}
