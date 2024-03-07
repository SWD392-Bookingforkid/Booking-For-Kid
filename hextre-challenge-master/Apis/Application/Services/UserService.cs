using Application.Commons;
using Application.Interfaces;
using Application.Utils;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentTime _currentTime;
        private readonly AppConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, AppConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentTime = currentTime;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(UserLoginDTO userObject)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetAsync(a => a.Email == userObject.Email && a.PasswordHash == userObject.Password.Hash());

                if (!user.Any())
                {
                    return "Invalid Email or PassWord";
                }

                var loggedInUser = user.First();

                var role = await _unitOfWork.RoleRepository.GetAsync(a => a.Id == loggedInUser.RoleID);

                return loggedInUser.GenerateJsonWebToken(role.FirstOrDefault(), _configuration.JWTSecretKey, _currentTime.GetCurrentTime());

            }
            catch (Exception exception)
            {
                throw new Exception("An error occurred while processing login: " + exception.Message);
            }
        }

        public async Task RegisterAsync(UserLoginDTO userObject)
        {
            try
            {
                // Kiểm tra xem username đã tồn tại chưa
                var isExists = await _unitOfWork.UserRepository.IsExistsAsync(u => u.Email.Equals(userObject.Email));

                if (isExists)
                {
                    throw new Exception("Email already exists. Please try again with a different email.");
                }

                var user = _mapper.Map<User>(userObject);
                user.PasswordHash = userObject.Password.Hash(); // Hash mật khẩu

                _unitOfWork.UserRepository.Insert(user);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception exception)
            {
                throw new Exception("An error occurred while registering: " + exception.Message);
            }
        }
    }
}