using AppServices.DTO;
using AppServices.DTOs;
using AppServices.Services.Interface;
using AppServices.Utility;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userService)
        {
            _userServices = userService;
        }

        
        [HttpGet]
        public async Task<ResultServices<UserDTO>> Login(string email, string password)
        {
            var LoggedUser = await _userServices.LoginAsync(email, password);
            return LoggedUser;
        }

        [HttpPost]
        public async Task<ResultServices<UserDTO>> CreateOrUpdateAsync(InsertUserDTO User)
        {
            var user = await _userServices.CreateOrUpdateAsync(User);
            return user;
        }
    }
}
