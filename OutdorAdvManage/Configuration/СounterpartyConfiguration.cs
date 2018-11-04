using OutdorAdvManage.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace OutdorAdvManage.Data.Configuration
{
    public class СounterpartyConfiguration : EntityTypeConfiguration<Counterparty>
    {
        public СounterpartyConfiguration()
        {
            ToTable("Сounterpartyes");
            Property(c => c.NameCompany).IsRequired().HasMaxLength(150);
        }
    }
}