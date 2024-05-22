using AutoMapper;
using MarketPlaceBLL.Models;
using MarketPlaceDAL.Entities;
using MarketPlaceDAL.UoW;

namespace MarketPlaceBLL.Services
{
    public class ShopService: MarketService
    {
        public ShopService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork) { }
        public async Task<bool> CreateShop(ShopCreateModel shopCreateModel, string userId)
        {
            Shop shop = _mapper.Map<Shop>(shopCreateModel);
            shop.OwnerId = userId;
            await _unitOfWork.GetRepository<Shop>().CreateAsync(shop);
            await _unitOfWork.Commit();

            return true;
        }
    }
}
