using MarketPlaceBLL.DTOs;
using MarketPlaceBLL.Models;
using MarketPlaceBLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MarketPlaceApi.Controllers
{
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetTopProducts/{count}")]
        public async Task<List<ProductDto>> GetTopProducts(int count)
        {
            return await _productService.GetTopProducts(count);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateModel product)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _productService.CreateProduct(product, userId);

            return Ok(product);
        }

        [Authorize(Roles = "keeper")]
        [HttpGet("GetUserProducts")]
        public async Task<List<ProductDto>> GetUserProducts()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _productService.GetUserProducts(userId);
        }


    }
}
