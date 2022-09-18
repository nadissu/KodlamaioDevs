using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetByIdLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologiesController :BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechnologyQuery getListLanguageTechnologyQuery = new() { PageRequest = pageRequest };
            LanguageTechnologyListModel result = await Mediator.Send(getListLanguageTechnologyQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand request)
        {
            CreateLanguageTechnologyCommand createLanguagetechnologyCommand = new() { Name = request.Name,ProgrammingLanguageId=request.ProgrammingLanguageId };
            CreatedLanguageTechnologyDto result = await Mediator.Send(createLanguagetechnologyCommand);
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageTechnologyCommand request)
        {
            DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand = new() { Id = request.Id };
            LanguageTechnologyDeleteDto result = await Mediator.Send(deleteLanguageTechnologyCommand);
            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnologyCommand request)
        {
            UpdateLanguageTechnologyCommand updateLanguageTechnologyCommand = new() { Id = request.Id, Name = request.Name };
            LanguageTechnologyUpdateDto result = await Mediator.Send(updateLanguageTechnologyCommand);
            return Ok(result);
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdLanguageTechnologyQuery request)
        {
            GetByIdLanguageTechnologyQuery getByIdLanguageTechnologyQuery = new() { Id = request.Id };
            LanguageTechnologyGetByIdDto result = await Mediator.Send(getByIdLanguageTechnologyQuery);
            return Ok(result);
        }
    }
}
