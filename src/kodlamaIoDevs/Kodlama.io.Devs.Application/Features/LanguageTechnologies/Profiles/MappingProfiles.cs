using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        
        public MappingProfiles()
        {
            CreateMap<LanguageTechnology, LanguageTechnologyListDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();
            CreateMap <IPaginate<LanguageTechnology>, LanguageTechnologyListModel>().ReverseMap();
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ForMember(a => a.ProgrammingLanguageId, opt => opt.MapFrom(a => a.ProgrammingLanguage.Id)).ReverseMap();
            CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ForMember(a => a.ProgrammingLanguageName, opt => opt.MapFrom(a => a.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<LanguageTechnology, LanguageTechnologyDeleteDto>().ReverseMap();
            CreateMap<LanguageTechnology, UpdateLanguageTechnologyCommand>().ReverseMap();
            CreateMap<LanguageTechnology, LanguageTechnologyUpdateDto>().ReverseMap();
            CreateMap<LanguageTechnology, LanguageTechnologyGetByIdDto>().ReverseMap();

        }
    }
}
