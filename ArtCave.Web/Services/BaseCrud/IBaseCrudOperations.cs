﻿namespace ArtCave.Web.Services.BaseCrud
{
    public interface IBaseCrudOperations<TEntity>
         where TEntity : class
    {
        public IQueryable<TEntity> GetAllAsQuery();

        public Task<TEntity> AddAsync(TEntity entity);

        public Task RemoveAsync(TEntity entity);

        public TEntity Update(TEntity entity);

        public Task<TEntity?> FindByIdAsync<TId>(TId id);
    }
}
