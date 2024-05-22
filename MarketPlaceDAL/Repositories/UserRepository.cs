using MarketPlaceDAL.DBContext;
using MarketPlaceDAL.Entities;
using MarketPlaceDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceDAL.Repositories
{
    public class UserRepository: IUserRepository
    {
        protected readonly MarketPlaceDBContext _marketPlaceDBContext;
        public UserRepository(MarketPlaceDBContext dBContext)
        {
            _marketPlaceDBContext = dBContext;
        }

        public async Task CreateAsync(User entity)
        {
            await _marketPlaceDBContext.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            _marketPlaceDBContext.Remove(entity);
        }

        public DbSet<User> GetAll()
        {
            return _marketPlaceDBContext.Set<User>();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _marketPlaceDBContext.Set<User>().FindAsync(id);
        }

        public Task<User> GetByIdWithDetailsAsync(string id)
        {
            return _marketPlaceDBContext.Users
                .Include(u=>u.Orders)
                .Include(u => u.Shops)
                .FirstAsync(u=>u.Id == id);
        }

        public void UpdateAsync(User entity)
        {
            _marketPlaceDBContext.Update(entity);
        }
    }
}
