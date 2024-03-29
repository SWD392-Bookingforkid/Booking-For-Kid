using Application.ViewModels.UserViewModels;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<string> RegisterAsync(UserLoginDTO userObject);
        public Task<string> LoginAsync(UserLoginDTO userObject);
    }
}