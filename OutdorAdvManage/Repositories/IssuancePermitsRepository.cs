using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;

namespace OutdorAdvManage.Data.Repositories
{
    public class IssuancePermitsRepository : RepositoryBase<IssuancePermit>, IIssuancePermitsRepository
    {
        public IssuancePermitsRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(IssuancePermit entity)
        {
            base.Update(entity);
        }
    }

    public interface IIssuancePermitsRepository : IRepository<IssuancePermit>
    {
    }
}