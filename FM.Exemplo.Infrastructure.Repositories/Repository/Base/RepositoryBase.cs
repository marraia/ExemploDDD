using FM.Exemplo.Domain.Entities;
using FM.Exemplo.Domain.Interfaces.Repositories.Base;
using FM.Exemplo.Infrastructure.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FM.Exemplo.Infrastructure.Repositories.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : Entity
    {
        protected int TimeOut => 30000; 
        protected readonly DbSet<TEntity> _db;
        protected readonly ExemploContext _context;

        protected RepositoryBase(ExemploContext context)
        {
            _context = context;
            _db = _context.Set<TEntity>();
            _context.Database.SetCommandTimeout(TimeOut);
        }


        public async Task<TEntity> AlterAsync(TEntity entity)
        {
            var currentEntity = await GetByIdAsync(entity.Id).ConfigureAwait(false);
            _context.Entry(currentEntity).CurrentValues.SetValues(entity);
            return entity;
        }

        public virtual Task DeleteAsync(TEntity entity)
        {
            return Task.FromResult(_db.Remove(entity));
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            var query =
                    await _db
                    .Where(where)
                    .OrderByDescending(ent => ent.Id)
                    .AsNoTracking()
                    .ToListAsync()
                    .ConfigureAwait(false);

            return query;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            var query = await _db
                        .OrderByDescending(ent => ent.Id)
                        .AsNoTracking().ToListAsync()
                        .ConfigureAwait(false);

            return query;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            Expression<Func<TEntity, bool>> predicate = t => t.Id.ToString() == id.ToString();
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
        }
    }
}
