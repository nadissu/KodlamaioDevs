using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetByIdLanguageTechnology
{
    public class GetByIdLanguageTechnologyQuery:IRequest<LanguageTechnologyGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdLanguageTechnologyQueryHandler : IRequestHandler<GetByIdLanguageTechnologyQuery, LanguageTechnologyGetByIdDto>
        {
            ILanguageTechnologyRepository _languageTechnologyRepository;
            IMapper _mapper;

            public GetByIdLanguageTechnologyQueryHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechnologyGetByIdDto> Handle(GetByIdLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                LanguageTechnology languageTechnology = await _languageTechnologyRepository.GetAsync(p => p.Id == request.Id);
                LanguageTechnologyGetByIdDto mappedLanguageTechnology = _mapper.Map<LanguageTechnologyGetByIdDto>(languageTechnology);
                return mappedLanguageTechnology;
            }
        }

    }
}
