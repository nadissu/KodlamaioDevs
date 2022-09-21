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

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand:IRequest<SocialMediaUpdateDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, SocialMediaUpdateDto>
        {
            ISocialMediaRepository _socialMediaRepository;
            IMapper _mapper;

            public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaUpdateDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                     
                var updateModel =await _socialMediaRepository.UpdateAsync(mappedSocialMedia);

                SocialMediaUpdateDto socialMediaUpdateDto = _mapper.Map<SocialMediaUpdateDto>(updateModel);

                return socialMediaUpdateDto;
            }
        }
    }
}
