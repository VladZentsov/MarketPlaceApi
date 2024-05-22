using MarketPlaceDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceDAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetByIdAsync(string id);
        public Task <User> GetByIdWithDetailsAsync(string id);
        public DbSet<User> GetAll();
        public void UpdateAsync(User entity);
        public Task CreateAsync(User entity);
        public Task DeleteByIdAsync(string id);
    }
}
