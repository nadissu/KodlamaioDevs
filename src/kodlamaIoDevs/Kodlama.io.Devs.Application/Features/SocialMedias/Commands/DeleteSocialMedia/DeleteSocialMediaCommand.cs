using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialMedias.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommand : IRequest<SocialMediaDeleteDto>
    {
        public int Id { get; set; }
        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, SocialMediaDeleteDto>
        {
            ISocialMediaRepository _socialMediaRepository;
            IMapper _mapper;

            public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaDeleteDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia mappedSocialMedia=_mapper.Map<SocialMedia>(request);
                var deleteResult = await  _socialMediaRepository.DeleteAsync(mappedSocialMedia);
                SocialMediaDeleteDto socialMediaDeleteDto = _mapper.Map<SocialMediaDeleteDto>(deleteResult);
                socialMediaDeleteDto.Description = $"{request.Id} ID'li Sosyal Medya hesabı Başarılı bir şekilde silinmiştir.";
                return socialMediaDeleteDto;
            }

            
        }
    }
}
