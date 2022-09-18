﻿using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models
{
    public class LanguageTechnologyListModel:BasePageableModel
    {
        public IList<LanguageTechnologyListDto> Items { get; set; }
    }
}
