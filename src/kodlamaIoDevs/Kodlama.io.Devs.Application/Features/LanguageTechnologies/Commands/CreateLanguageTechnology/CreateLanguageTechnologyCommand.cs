using AutoMapper;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class CreateLanguageTechnologyCommand:IRequest<CreatedLanguageTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public class CreateLanguageTechnologyCommandHandler : IRequestHandler<CreateLanguageTechnologyCommand, CreatedLanguageTechnologyDto>
        {

            ILanguageTechnologyRepository _languageTechnologyRepository;
            IProgrammingLanguageRepository _programmingLanguageRepository;
            IMapper _mapper;

            public CreateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<CreatedLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.ProgrammingLanguageId);
                LanguageTechnology mapperLanguageTechnology = _mapper.Map<LanguageTechnology>(request);
                mapperLanguageTechnology.ProgrammingLanguage = programmingLanguage;
                LanguageTechnology languageTechnology = await _languageTechnologyRepository.AddAsync(mapperLanguageTechnology);
                CreatedLanguageTechnologyDto responseCreatedLanguageTechnologyDto = _mapper.Map<CreatedLanguageTechnologyDto>(languageTechnology);
                return responseCreatedLanguageTechnologyDto;


            }
        }
    }
}
