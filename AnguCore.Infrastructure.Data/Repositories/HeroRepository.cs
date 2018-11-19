using AnguCore.Core.Data.Interfaces.Repositories;
using AnguCore.Core.Entities;
using AnguCore.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnguCore.Infrastructure.Data.Repositories
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepository
    {
        public HeroRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
