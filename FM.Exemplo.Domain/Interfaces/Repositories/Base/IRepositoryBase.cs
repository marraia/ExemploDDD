using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FM.Exemplo.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity>
    {
        Task InsertAsync(TEntity entity);
        Task<TEntity> AlterAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<IEnumerable<TEntity>> GetAsync();
    }
}
