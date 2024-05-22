using MarketPlaceDAL.DBContext;
using MarketPlaceDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceDAL.Repositories
{
    public class Repository<T>: CRUDRepository<T> where T : class
    {
        protected readonly MarketPlaceDBContext _marketPlaceDBContext;
        public Repository(MarketPlaceDBContext dBContext)
        {
            _marketPlaceDBContext = dBContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _marketPlaceDBContext.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _marketPlaceDBContext.Remove(entity);
        }

        public DbSet<T> GetAll()
        {
            return _marketPlaceDBContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _marketPlaceDBContext.Set<T>().FindAsync(id);
        }

        public void UpdateAsync(T entity)
        {
            _marketPlaceDBContext.Update(entity);
        }
    }
}
