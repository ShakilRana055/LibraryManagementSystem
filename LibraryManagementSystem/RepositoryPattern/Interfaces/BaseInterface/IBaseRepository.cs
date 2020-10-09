using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementSystem.RepositoryPattern.Interfaces.BaseInterface
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        // Searching Objects
        Task<TEntity> Get(int Id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        // Saving objects
        void Save(TEntity entity);
        void SaveAll(IEnumerable<TEntity> entities);

        // Removing objects
        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);
    }
}
