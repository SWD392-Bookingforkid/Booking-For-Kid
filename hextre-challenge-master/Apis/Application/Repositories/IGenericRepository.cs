using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? pageIndex = null,
            int? pageSize = null);

        Task<TEntity> GetByIDAsync(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
        Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
