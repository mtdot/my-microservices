using System;
using System.Linq;
using System.Linq.Expressions;
using AccountService.Repository.Contracts;
using AccountService.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Repository.Implements
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> 
        where TEntity : EntityBase<TKey> 
        where TKey : IEquatable<TKey> 
    {
        private readonly AccountDbContext _dbContext;

        protected Repository(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, bool needTracking = false)
        {
            if (needTracking)
            {
                return _dbContext.Set<TEntity>().Where(predicate);
            }

            return _dbContext.Set<TEntity>().AsNoTracking().Where(predicate);
        }
    }

    public class Repository<TEntity> : Repository<TEntity, Guid> where TEntity : EntityBase
    {
        public Repository(AccountDbContext dbContext) : base(dbContext)
        {
        }
    }
}