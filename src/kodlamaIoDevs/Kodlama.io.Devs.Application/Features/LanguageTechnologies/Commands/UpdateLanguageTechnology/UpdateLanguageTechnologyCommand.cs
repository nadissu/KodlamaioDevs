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

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommand:IRequest<LanguageTechnologyUpdateDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateLanguageTechnologyCommandHandler : IRequestHandler<UpdateLanguageTechnologyCommand, LanguageTechnologyUpdateDto>
        {
            ILanguageTechnologyRepository _languageTechnologyRepository;
            IMapper _mapper;

            public UpdateLanguageTechnologyCommandHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechnologyUpdateDto> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var getLanguageTechnology = await _languageTechnologyRepository.GetAsync(x=>x.Id==request.Id);
                var languageTechnology = _mapper.Map(request,getLanguageTechnology);
                LanguageTechnology response = _languageTechnologyRepository.Update(languageTechnology);
                LanguageTechnologyUpdateDto responseUpdatedLanguageTechnology = _mapper.Map<LanguageTechnologyUpdateDto>(response);
                return responseUpdatedLanguageTechnology;
            }
        }
    }
}
