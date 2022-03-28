using AppServices.DTO;
using AppServices.DTOs;
using AppServices.Services.Interface;
using AppServices.Utility;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : Controller
    {
        private readonly IUserTypeService _userTypeServices;

        public UserTypeController(IUserTypeService userTypeServicesService)
        {
            _userTypeServices = userTypeServicesService;
        }
        [HttpPost]
        public async Task<ResultServices<UserTypeDTO>> CreateOrUpdateAsync(InsertUserTypeDTO userType)
        {
            var usertype = await _userTypeServices.CreateOrUpdateAsync(userType);
            return usertype;
        }
    }
}
