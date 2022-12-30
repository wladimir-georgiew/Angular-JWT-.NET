using ArtCave.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace ArtCave.Web.Services.BaseCrud
{
    public class BaseCrudOperations<TEntity> : IBaseCrudOperations<TEntity>
        where TEntity : class
    {
        protected DbSet<TEntity> DbSet { get; set; }
        protected ArtCaveDbContext Context { get; set; }

        public BaseCrudOperations(ArtCaveDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        public virtual Task<TEntity[]> GetAllAsync()
        {
            return this.DbSet.ToArrayAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = await this.DbSet.AddAsync(entity);
            await this.Context.SaveChangesAsync();

            return addedEntity.Entity;
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            this.DbSet.Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        public virtual TEntity Update(TEntity entity)
        {
            var updatedEntity = this.DbSet.Update(entity);
            return updatedEntity.Entity;
        }

        public virtual async Task<TEntity?> FindByIdAsync<TId>(TId id)
        {
            return await this.DbSet.FindAsync(id) ?? null;
        }
    }
}
