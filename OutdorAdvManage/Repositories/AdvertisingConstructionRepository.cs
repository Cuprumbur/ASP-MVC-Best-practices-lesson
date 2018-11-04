using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;

namespace OutdorAdvManage.Data.Repositories
{
    public class AdvertisingConstructionRepository : RepositoryBase<AdvertisingConstruction>, IAdvertisingConstructionRepository
    {
        public AdvertisingConstructionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(AdvertisingConstruction entity)
        {
            base.Update(entity);
        }
    }

    public interface IAdvertisingConstructionRepository : IRepository<AdvertisingConstruction>
    {
    }
}