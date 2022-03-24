using SV.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SV.Core.Interfaces.Repositories.Generic
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entidade
    {
        Task<TEntity> FindAsync(Guid id);

        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string inCludeProperties = null,
            bool isTracking = true);

        Task<TEntity> FirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string inCludeProperties = null,
            bool isTracking = true);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        Task SaveChangesAsync();
    }
}
