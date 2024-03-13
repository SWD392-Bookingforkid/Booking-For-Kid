using Application.Interfaces;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task RegisterAsync(UserLoginDTO loginObject) => await _userService.RegisterAsync(loginObject);

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            var user = await _userService.LoginAsync(model);
            if (user == null)
            {
                _logger.LogWarning($"Không tìm thấy người dùng với tên {model.Email}.");
                return Unauthorized();
            }

            if (user != "Invalid Email or Password, Please try again !! ")
            {
                _logger.LogInformation($"Người dùng {model.Email} đã đăng nhập thành công.");
                return Ok();
            }
            else
            {
                _logger.LogError($"Đăng nhập thất bại cho người dùng {model.Email}");
                return Unauthorized();
            }
        }

    }
}