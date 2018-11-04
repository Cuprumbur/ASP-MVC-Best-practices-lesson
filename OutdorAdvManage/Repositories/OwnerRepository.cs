using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;

namespace OutdorAdvManage.Data.Repositories
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(Owner entity)
        {
            base.Update(entity);
        }
    }

    public interface IOwnerRepository : IRepository<Owner>
    {
    }
}