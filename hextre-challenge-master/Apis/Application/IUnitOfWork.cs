using Application.Repositories;
using Domain.Entities;

namespace Application
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
