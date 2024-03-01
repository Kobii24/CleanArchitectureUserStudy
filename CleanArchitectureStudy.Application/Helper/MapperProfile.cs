using AutoMapper;
using CleanArchitectureStudy.Application.VM;
using CleanArchitectureStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudy.Application.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserVM>()
                .ForMember(u => u.userName, option => option.MapFrom(x => x.userName))
                .ForMember(u => u.userEmail, option => option.MapFrom(x => x.userEmail)); 
        }

    }
}
