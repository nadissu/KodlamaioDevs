using Kodlama.io.Devs.Application.Features.Auth.Commands.RegisterUser;
using Kodlama.io.Devs.Application.Features.Auth.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
        {
            RegisterUserCommand registerUserCommand = new() { FirstName=request.FirstName,LastName=request.LastName,Password=request.Password,Email=request.Email };
            RegisterUserDto result = await Mediator.Send(registerUserCommand);
            return Ok(result);
        }
    }
}
