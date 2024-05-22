//using MarketPlaceDAL.DBContext;
//using MarketPlaceDAL.Entities;
//using MarketPlaceDAL.Repositories.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MarketPlaceDAL.Repositories
//{
//    public class OrderRepository : IOrderRepository
//    {
//        public readonly MarketPlaceDBContext _marketPlaceDBContext;
//        public OrderRepository(MarketPlaceDBContext dBContext)
//        {
//            _marketPlaceDBContext = dBContext;
//        }
//         async Task CreateAsync(Order entity)
//        {
//            await _marketPlaceDBContext.AddAsync(entity);
//        }

//        public async Task DeleteByIdAsync(int id)
//        {
//            var order = await GetByIdAsync(id);
//            _marketPlaceDBContext.Remove(order);
//        }

//        public IQueryable<Order> GetAll()
//        {
//            return _marketPlaceDBContext.Orders;
//        }

//        public async Task<Order> GetByIdAsync(int id)
//        {
//            var order =  await _marketPlaceDBContext.Orders.FindAsync(id);
//        }

//        public Task UpdateAsync(Order entity)
//        {
//            _marketPlaceDBContext.Update(entity);
//        }
//    }
//}
