using AnguCore.Core.Data.Interfaces;
using AnguCore.Core.Entities;
using AnguCore.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnguCore.Infrastructure.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IApplicationDbContext _dbContext;

        public BaseRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();

            if (result > 0)
                return entity.Id;
            else
                return -1;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
