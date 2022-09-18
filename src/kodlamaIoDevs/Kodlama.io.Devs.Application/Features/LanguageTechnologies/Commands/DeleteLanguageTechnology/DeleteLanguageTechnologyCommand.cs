using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology
{
    public class DeleteLanguageTechnologyCommand:IRequest<LanguageTechnologyDeleteDto>
    {
        public int Id { get; set; }
        public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, LanguageTechnologyDeleteDto>
        {
            ILanguageTechnologyRepository _languageTechnologyRepository;
            IMapper _mapper;

            public DeleteLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechnologyDeleteDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                LanguageTechnology getLanguageTechnology = await _languageTechnologyRepository.GetAsync(p => p.Id == request.Id);
                if (getLanguageTechnology != null)
                {
                    LanguageTechnology languageTechnology = await _languageTechnologyRepository.DeleteAsync(getLanguageTechnology);
                    LanguageTechnologyDeleteDto mappedLanguageTechnologyDelete = _mapper.Map<LanguageTechnologyDeleteDto>(languageTechnology);
                    return mappedLanguageTechnologyDelete;
                }
                else
                {
                    throw new BusinessException("Bu Id'ye ait ürün bulunmamaktadır.");
                }
            }
        }
    }
}
