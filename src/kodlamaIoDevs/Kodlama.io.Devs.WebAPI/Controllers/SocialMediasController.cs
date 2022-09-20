using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.SocialMedias.Commands.CreateSocialMedia;
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
            CreateSocialMediaCommand createSocialMediaCommand = new() { Name = request.Name,Url = request.Url,UserId=request.UserId };
            SocialMediaCreateDto result = await Mediator.Send(createSocialMediaCommand);
            return Ok(result);
        }
    }
}
