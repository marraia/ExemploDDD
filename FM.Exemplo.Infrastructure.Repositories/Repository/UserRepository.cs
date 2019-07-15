using FM.Exemplo.Domain.Entities;
using FM.Exemplo.Domain.Interfaces.Repositories;
using FM.Exemplo.Infrastructure.Repositories.Context;
using FM.Exemplo.Infrastructure.Repositories.Repository.Base;

namespace FM.Exemplo.Infrastructure.Repositories.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ExemploContext context)
        : base(context)
        {
            
        }
    }
}
