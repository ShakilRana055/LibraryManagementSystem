using LibraryManagementSystem.Data;
using LibraryManagementSystem.RepositoryPattern.Interfaces.BaseInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementSystem.RepositoryPattern.Repositories.BaseRepository
{
    public class BaseRepository<TEntity> :IBaseRepository<TEntity> where TEntity:class
    {
        private readonly AppDbContext context;
        public BaseRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        // Implementing IBaseRepository

        #region Searching
        public async Task<TEntity> Get(int Id)
        {
            return await context.Set<TEntity>().FindAsync(Id);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }
        public async Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        #endregion

        #region Saving
        public void Save(TEntity entity)
        {
            context.Set<TEntity>().AddAsync(entity);
        }
        public void SaveAll(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRangeAsync(entities);
        }
        #endregion

        #region Deleting
        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
        public void RemoveAll(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }
        #endregion
    }
}
