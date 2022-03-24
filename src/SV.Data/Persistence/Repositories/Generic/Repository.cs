using Microsoft.EntityFrameworkCore;
using SV.Core.Entities.Base;
using SV.Core.Interfaces.Repositories.Generic;
using SV.Data.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SV.Data.Persistence.Repositories.Generic
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entidade
    {
        protected readonly ApplicationDbContext _db;
        private readonly DbSet<TEntity> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<TEntity> FindAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, string inCludeProperties = null, bool isTracking = true)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (inCludeProperties != null)
            {
                foreach (var inCludeProp in inCludeProperties.Split(new char[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(inCludeProp);
                }
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string inCludeProperties = null, bool isTracking = true)
        {
            IQueryable<TEntity> query = dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(inCludeProperties != null)
            {
                foreach(var inCludeProp in inCludeProperties.Split(new char[] {','}, 
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(inCludeProp);
                }
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            if(!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await  _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
