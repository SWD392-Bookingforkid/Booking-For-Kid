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
                    return "Invalid Email or Password, Please try again !! ";
                }

                var loggedInUser = user.FirstOrDefault();

                var role = await _unitOfWork.RoleRepository.GetAsync(a => a.Id == loggedInUser.RoleID);

                return loggedInUser.GenerateJsonWebToken(role.FirstOrDefault(), _configuration.JWTSecretKey, _currentTime.GetCurrentTime());

            }
            catch (Exception exception)
            {
                throw new Exception("An error occurred while processing login: " + exception.Message);
            }
        }

        public async Task<string> RegisterAsync(UserLoginDTO userObject)
        {
            try
            {
                // Check user with the email is existed ?
                var isExists = await _unitOfWork.UserRepository.IsExistsAsync(u => u.Email.Equals(userObject.Email));

                if (isExists)
                {
                    return "Email already exists. Please try again with a different email.";
                }

                var user = _mapper.Map<User>(userObject);
                user.PasswordHash = userObject.Password.Hash(); // Hash password

                user.RoleID = (await _unitOfWork.RoleRepository.GetAsync(a => a.Name == "Guest")).FirstOrDefault().Id;

                _unitOfWork.UserRepository.Insert(user);
                await _unitOfWork.SaveChangeAsync();

                return "Registered successfully";
            }
            catch (Exception exception)
            {
                throw new Exception("An error occurred while registering: " + exception.Message);
            }
        }
    }
}