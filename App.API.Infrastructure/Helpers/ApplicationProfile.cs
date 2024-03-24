using App.Core.APIDto.ApplicationUserDto;
using App.Core.APIViewModel;
using App.Data.DbEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.API.Infrastructure.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, PublicUserViewModel>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.ApplicationUser.FullName))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.ApplicationUser.UserName))
            .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.ApplicationUser.Interests))
            .ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.ApplicationUser.Introduction))
            .ForMember(dest => dest.LookingFor, opt => opt.MapFrom(src => src.ApplicationUser.LookingFor))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.ApplicationUser.Phone))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.ApplicationUser.getAge()))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.ApplicationUser.Gender))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.ApplicationUser.IsActive))
            .ForMember(dest => dest.Created_At, opt => opt.MapFrom(src => src.ApplicationUser.Created_At))
            .ForMember(dest => dest.Updated_at, opt => opt.MapFrom(src => src.ApplicationUser.Updated_at))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.ApplicationUser.City))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.ApplicationUser.Country))
            .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.ApplicationUser.ImageName)).ReverseMap();

            CreateMap<User, UpdateApplicationUserDto>().ForMember(dest => dest.Introduction, opt => opt.MapFrom(src => src.ApplicationUser.Introduction))
            .ForMember(dest => dest.Interests, opt => opt.MapFrom(src => src.ApplicationUser.Interests))
            .ForMember(dest => dest.LookingFor, opt => opt.MapFrom(src => src.ApplicationUser.LookingFor))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.ApplicationUser.City))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.ApplicationUser.Country)).ReverseMap();
        }
    }
}
