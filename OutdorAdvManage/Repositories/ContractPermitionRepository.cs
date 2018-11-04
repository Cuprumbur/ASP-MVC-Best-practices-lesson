using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;

namespace OutdorAdvManage.Data.Repositories
{
    public class ContractPermitionRepository : RepositoryBase<ContractPermition>, IContractPermitionRepository
    {
        public ContractPermitionRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(ContractPermition entity)
        {
            base.Update(entity);
        }
    }

    public interface IContractPermitionRepository : IRepository<ContractPermition>
    {
    }
}