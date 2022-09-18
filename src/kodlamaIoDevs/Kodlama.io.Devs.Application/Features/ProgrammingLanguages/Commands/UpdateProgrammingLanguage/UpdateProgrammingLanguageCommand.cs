using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand:IRequest<ProgrammingLanguageUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingLanguageCommandHandle : IRequestHandler<UpdateProgrammingLanguageCommand, ProgrammingLanguageUpdateDto>
        {
            IProgrammingLanguageRepository _programmingLanguageRepository;
            IMapper _mapper;
            ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandle(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<ProgrammingLanguageUpdateDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                
                await _programmingLanguageBusinessRules.ProgrammingLanguageShouldBeExistWhenRequested(request.Id);
                var getProgrammingLanguage = await _programmingLanguageRepository.GetAsync(x=>x.Id==request.Id);
                var programmingLanguage = _mapper.Map(request, getProgrammingLanguage);
                ProgrammingLanguage response =  _programmingLanguageRepository.Update(programmingLanguage);
                ProgrammingLanguageUpdateDto responseUpdatedProgrammingLanguageDto = _mapper.Map<ProgrammingLanguageUpdateDto>(response);
                return responseUpdatedProgrammingLanguageDto;

            }
        }
    }
}
