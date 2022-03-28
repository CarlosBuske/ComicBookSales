using AppServices.DTOs;
using AppServices.Services.Interface;
using AppServices.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyController : ControllerBase
    {
        private readonly IBuyService _buyServices;

        public BuyController(IBuyService buyService)
        {
            _buyServices = buyService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [Route("Checkout")]
        public async Task<ResultServices> Checkout(CheckoutDTO checkouDTO)
        {
            var ResultCheckout = await _buyServices.Checkout(checkouDTO);
            return ResultCheckout;
        }
    }
}
