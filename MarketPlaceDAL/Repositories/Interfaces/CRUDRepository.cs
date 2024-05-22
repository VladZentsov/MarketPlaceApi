using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceDAL.Repositories.Interfaces
{
    public interface CRUDRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(int id);
        public DbSet<T> GetAll();
        public void UpdateAsync(T entity);
        public Task CreateAsync(T entity);
        public Task DeleteByIdAsync(int id);
    }
}
