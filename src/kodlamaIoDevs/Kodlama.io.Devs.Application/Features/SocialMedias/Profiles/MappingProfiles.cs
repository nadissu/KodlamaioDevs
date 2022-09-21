using AutoMapper;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<SocialMedia,SocialMediaCreateDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateDto>().ReverseMap();
            CreateMap<SocialMedia, DeleteSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMediaDeleteDto, SocialMedia>().ReverseMap();
        }
       
    }
}
