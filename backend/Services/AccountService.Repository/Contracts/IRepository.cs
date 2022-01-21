using System;
using System.Linq;
using System.Linq.Expressions;
using AccountService.Repository.Models;

namespace AccountService.Repository.Contracts
{
    public interface IRepository<TEntity, TKey>
    {
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool needTracking = false);
    }

    public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : EntityBase
    {
        
    }
}