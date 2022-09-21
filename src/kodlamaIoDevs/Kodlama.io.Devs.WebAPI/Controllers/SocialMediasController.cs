using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Kodlama.io.Devs.Application.Features.SocialMedias.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand request)
        {
            CreateSocialMediaCommand createSocialMediaCommand = new() { Name = request.Name, Url = request.Url, UserId = request.UserId };
            SocialMediaCreateDto result = await Mediator.Send(createSocialMediaCommand);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCommand request)
        {
            UpdateSocialMediaCommand updateSocialMediaCommand = new() { Id = request.Id, Name = request.Name, Url = request.Url, UserId = request.UserId };
            SocialMediaUpdateDto result = await Mediator.Send(updateSocialMediaCommand);
            return Ok(result);

        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialMediaCommand request)
        {
            DeleteSocialMediaCommand deleteSocialMediaCommand = new() { Id = request.Id};
            SocialMediaDeleteDto result = await Mediator.Send(deleteSocialMediaCommand);
            return Ok(result);
        }
    }
}
