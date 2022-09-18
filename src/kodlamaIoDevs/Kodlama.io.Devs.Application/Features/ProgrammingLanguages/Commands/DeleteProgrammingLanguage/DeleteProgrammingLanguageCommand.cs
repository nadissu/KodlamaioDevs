using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand:IRequest<ProgrammingLanguageDeleteDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, ProgrammingLanguageDeleteDto>
        {
            IProgrammingLanguageRepository _programmingLanguageRepository;
            IMapper _mapper;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageDeleteDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage getProgrammingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                if (getProgrammingLanguage != null)
                {
                    ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.DeleteAsync(getProgrammingLanguage);
                    ProgrammingLanguageDeleteDto mappedProgrammingLanguageDelete = _mapper.Map<ProgrammingLanguageDeleteDto>(programmingLanguage);
                    return mappedProgrammingLanguageDelete;
                }
                else
                {
                    throw new BusinessException("Bu Id'ye ait ürün bulunmamaktadır.");
                }
                
            }
        }
    }
}
