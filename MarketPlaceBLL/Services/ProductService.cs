using AutoMapper;
using MarketPlaceBLL.DTOs;
using MarketPlaceBLL.Models;
using MarketPlaceDAL.Entities;
using MarketPlaceDAL.UoW;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceBLL.Services
{
    public class ProductService: MarketService
    {
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork) :base(mapper, unitOfWork) { }
        public async Task<List<ProductDto>> GetTopProducts(int count)
        {
            var products = _unitOfWork.GetRepository<Product>()
                .GetAll()
                .Include(p => p.Category)
                .Take(count)
                .ToList();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }
        public async Task<List<ProductDto>> GetUserProducts(string userId)
        {
            int? shopId = GetShopIdFromUserId(userId);

            var products = _unitOfWork.GetRepository<Product>()
                .GetAll()
                .Include(p => p.Category)
                .Where(p=>p.ShopId == shopId)
                .ToList();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public async Task<bool> CreateProduct(ProductCreateModel productCreateModel, string userId)
        {
            int shopId = GetShopIdFromUserId(userId);

            Product product = _mapper.Map<Product>(productCreateModel);
            product.ShopId = shopId;

            await _unitOfWork.GetRepository<Product>().CreateAsync(product);
            await _unitOfWork.Commit();

            return true;
        }

        private int GetShopIdFromUserId(string userId)
        {
            var user = _unitOfWork.GetUserRepository()
            .GetAll()
            .Include(u => u.Shops)
            .FirstOrDefault(u => u.Id == userId);

            if(user == null || user.Shops==null || user.Shops.Count == 0)
                throw new ArgumentNullException();

            var shop = user.Shops.FirstOrDefault();

            if(shop == null)
                throw new ArgumentNullException();

            return shop.Id;
        }
    }
}
