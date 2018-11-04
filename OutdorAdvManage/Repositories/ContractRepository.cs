using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;

namespace OutdorAdvManage.Data.Repositories
{
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(Contract entity)
        {
            base.Update(entity);
        }
    }

    public interface IContractRepository : IRepository<Contract>
    {
    }
}