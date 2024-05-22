using MarketPlaceDAL.DBContext;
using MarketPlaceDAL.Entities;
using MarketPlaceDAL.Repositories;
using MarketPlaceDAL.Repositories.Interfaces;

namespace MarketPlaceDAL.UoW
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly MarketPlaceDBContext _marketPlaceDBContext;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public UnitOfWork(MarketPlaceDBContext marketPlaceDBContext)
        {
            _marketPlaceDBContext = marketPlaceDBContext;
        }

        public async Task Commit()
        {
            await _marketPlaceDBContext.SaveChangesAsync();
        }

        public CRUDRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (CRUDRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(_marketPlaceDBContext);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }
        public IUserRepository GetUserRepository()
        {
            if (_repositories.ContainsKey(typeof(User)))
            {
                return (IUserRepository)_repositories[typeof(User)];
            }

            var repository = new UserRepository(_marketPlaceDBContext);
            _repositories.Add(typeof(User), repository);
            return repository;
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
