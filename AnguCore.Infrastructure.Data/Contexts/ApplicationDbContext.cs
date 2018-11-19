using AnguCore.Core.Entities;
using AnguCore.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AnguCore.Infrastructure.Data.Contexts
{
    public interface IApplicationDbContext :IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, ApplicationIdentityRole, int, ApplicationIdentityUserClaim, ApplicationIdentityUserRole, ApplicationIdentityUserLogin, ApplicationIdentityRoleClaim, ApplicationIdentityUserToken>, IApplicationDbContext
    {
        #region dbset
        public DbSet<Hero> Heroes { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.DisableDeleteCascade();

            modelBuilder.Seed();
        }
    }
}
