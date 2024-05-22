using MarketPlaceDAL.Entities;
using MarketPlaceDAL.Repositories;
using MarketPlaceDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceDAL.UoW
{
    public interface IUnitOfWork
    {
        Task Commit();
        void Rollback();
        CRUDRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        public IUserRepository GetUserRepository();
    }
}
