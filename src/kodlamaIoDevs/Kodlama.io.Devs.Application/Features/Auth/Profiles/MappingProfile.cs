using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Auth.Commands.RegisterUser;
using Kodlama.io.Devs.Application.Features.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Auth.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
        }
    }
}
