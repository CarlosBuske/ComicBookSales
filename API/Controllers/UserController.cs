using AppServices.DTO;
using AppServices.DTOs;
using AppServices.Services.Interface;
using AppServices.Utility;
using Domain.Account;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly ISeedRoleInitial _seedRoleInitial;

        public UserController (IAuthenticate authentication, ISeedRoleInitial seedRoleInitial)
        {
            _authentication = authentication;
            _seedRoleInitial = seedRoleInitial;

            _seedRoleInitial.SeedRoles();
            _seedRoleInitial.SeedUsers();
        }

        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResultServices> Login(string email, string password)
        {
            var LoggedUser = await _authentication.Authenticate(email, password);
            if (!LoggedUser)
                return ResultServices.Fail(String.Format("Email ou senha invalido!"));
            else
                return ResultServices.Ok("Usuario logado!");
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ResultServices> Register(InsertUserDTO User)
        {
            var registerUser = await _authentication.RegisterUser(User.Name, User.Email, User.Password);
            if (registerUser)
                return ResultServices.Ok("Usuario registrado!");
            else
                return ResultServices.Fail(String.Format("Falha ao registrar!"));

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ResultServices> UpdateUser(InsertUserDTO User)
        {
            var registerUser = await _authentication.UpdateUser(User.Id.ToString(), User.Name, User.Email, User.Password);
            if (registerUser)
                return ResultServices.Ok("Usuario atualizar registro!");
            else
                return ResultServices.Fail(String.Format("Falha ao atualizar registro!"));

        }

        [HttpGet]
        public async Task<ResultServices> Logout()
        {
            await _authentication.Logout();
            return ResultServices.Ok("Logout efetuado!");
        }

    }
}
