
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage.DeleteProgrammingLanguageCommand;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand request )
        {
            CreateProgrammingLanguageCommand createProgrammingLanguageCommand = new() {Name= request.Name };
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand request)
        {
            DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand = new() { Id = request.Id};
            ProgrammingLanguageDeleteDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProgrammingLanguageQuery request)
        {
            GetByIdProgrammingLanguageQuery getByIdProgrammingLanguage = new() { Id = request.Id };
            ProgrammingLanguageGetByIdDto result = await Mediator.Send(getByIdProgrammingLanguage);
            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand request)
        {
            UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand = new() { Id = request.Id,Name=request.Name };
            ProgrammingLanguageUpdateDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }
    }
}
