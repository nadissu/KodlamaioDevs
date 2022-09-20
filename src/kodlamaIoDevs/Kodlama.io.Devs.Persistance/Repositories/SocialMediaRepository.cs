﻿using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistance.Repositories
{
    public class SocialMediaRepository : EfRepositoryBase<SocialMedia, MsSqlDbContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(MsSqlDbContext context) : base(context)
        {
        }
    }
}
