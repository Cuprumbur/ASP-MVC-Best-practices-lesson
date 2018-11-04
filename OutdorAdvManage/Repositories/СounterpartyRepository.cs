using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;

namespace OutdorAdvManage.Data.Repositories
{
    public class СounterpartyRepository : RepositoryBase<Counterparty>, ICounterpartyRepository
    {
        public СounterpartyRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(Counterparty entity)
        {
            base.Update(entity);
        }
    }

    public interface ICounterpartyRepository : IRepository<Counterparty>
    {
    }
}