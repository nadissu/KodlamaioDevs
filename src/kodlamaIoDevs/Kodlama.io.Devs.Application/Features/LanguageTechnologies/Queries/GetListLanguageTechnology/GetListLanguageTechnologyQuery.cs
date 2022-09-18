using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology
{
    public class GetListLanguageTechnologyQuery:IRequest<LanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListLanguageTechnologyQueryHandler : IRequestHandler<GetListLanguageTechnologyQuery, LanguageTechnologyListModel>
        {
            ILanguageTechnologyRepository _languageTechnologyRepository;
            IMapper _mapper;

            public GetListLanguageTechnologyQueryHandler(ILanguageTechnologyRepository languageTechnologyRepository, IMapper mapper)
            {
                _languageTechnologyRepository = languageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<LanguageTechnologyListModel> Handle(GetListLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<LanguageTechnology> LanguageTechnology =await _languageTechnologyRepository.GetListAsync(
                    include:x=>x.Include(a=>a.ProgrammingLanguage),
                    index: request.PageRequest.Page, 
                    size: request.PageRequest.PageSize);
                LanguageTechnologyListModel languageTechnologyListModel = _mapper.Map<LanguageTechnologyListModel>(LanguageTechnology);
                return languageTechnologyListModel;
            }
        }
    }
}
