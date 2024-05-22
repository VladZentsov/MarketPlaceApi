using MarketPlaceBLL.Models;
using MarketPlaceBLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlaceApi.Controllers
{
    [Route("Shop")]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;
        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost("CreateShop")]
        public async Task<IActionResult> CreateShop([FromBody] ShopCreateModel shopCreateModel)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _shopService.CreateShop(shopCreateModel, userId);
            return Ok();
        }
    }
}
