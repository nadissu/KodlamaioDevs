using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
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

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommand:IRequest<SocialMediaCreateDto>
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Url { get; set; }
        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, SocialMediaCreateDto>
        {
            private readonly ISocialMediaRepository _socailMediaRepository;
            private readonly IMapper _mapper;

            public CreateSocialMediaCommandHandler(ISocialMediaRepository socailMediaRepository, IMapper mapper)
            {
                _socailMediaRepository = socailMediaRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaCreateDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia mapperSocialMedia = _mapper.Map<SocialMedia>(request);
                SocialMedia socialMedia = await _socailMediaRepository.AddAsync(mapperSocialMedia);
                SocialMediaCreateDto responseSocailMediaCreateDto = _mapper.Map<SocialMediaCreateDto>(socialMedia);
                return responseSocailMediaCreateDto;

            }
        }
    }
}
