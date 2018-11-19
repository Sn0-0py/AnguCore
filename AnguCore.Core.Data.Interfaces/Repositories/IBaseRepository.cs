using AnguCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnguCore.Core.Data.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(int id);

        Task<int> Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
