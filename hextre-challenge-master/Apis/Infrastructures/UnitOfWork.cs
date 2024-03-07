using Application;
using Application.Repositories;
using Domain.Entities;
using Infrastructures.Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IGenericRepository<User>? userRepository;
        private IGenericRepository<Role>? roleRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(_dbContext);
                }
                return userRepository;
            }
        }

        public IGenericRepository<Role> RoleRepository
        {
            get
            {

                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(_dbContext);
                }
                return roleRepository;
            }
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
