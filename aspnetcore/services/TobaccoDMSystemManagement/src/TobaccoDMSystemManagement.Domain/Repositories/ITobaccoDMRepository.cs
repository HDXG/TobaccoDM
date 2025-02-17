using System.Linq.Expressions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace TobaccoDMSystemManagement.Domain.Repositories
{
    public interface ITobaccoDMRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {

        Task<(int, List<TEntity>)> GetPagedListAsync<Key>(int skipCount, int taskCount, Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate, bool isReverse = true);

        Task<(int, List<TEntity>)> GetPagedListAsync<Key>(Expression<Func<TEntity, bool>> wherePredicate, Func<TEntity, Key> orderPredicate, bool isReverse = true, int pageIndex = 1, int pageSize = 10);

        

        Task<bool> DeleteAsync(TEntity entity);

        Task<TEntity> GetIncludeAsync(Expression<Func<TEntity, bool>> wherePredicate, Expression<Func<TEntity, IEnumerable<TEntity>>> includePredicate);

        Task<List<TEntity>> GetListIncludeAsync(Expression<Func<TEntity, bool>> wherePredicate, Expression<Func<TEntity, IEnumerable<TEntity>>> includePredicate);

    }
}
