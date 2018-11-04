using OutdorAdvManage.Model.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace OutdorAdvManage.Data
{
    public class OutdorAdvManageData : DropCreateDatabaseIfModelChanges<OutdorAdvManageEntities>
    {
        protected override void Seed(OutdorAdvManageEntities context)
        {
            GetCounterparty().ForEach(x => context.Counterpartys.Add(x));
            context.Commit();
        }

        private List<Counterparty> GetCounterparty()
        {
            return new List<Counterparty>
            {
                new Counterparty { NameCompany  = "Рога и копыта"}
            };
        }
    }
}