using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;

namespace OutdorAdvManage.Data.Repositories
{
    public class ResolutionRepository : RepositoryBase<Resolution>, IResolutionRepository
    {
        public ResolutionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(Resolution entity)
        {
            base.Update(entity);
        }
    }

    public interface IResolutionRepository : IRepository<Resolution>
    {
    }
}