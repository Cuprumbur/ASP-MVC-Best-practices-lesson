//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;
using OutdorAdvManage.Data.Configuration;
using OutdorAdvManage.Model.Models;
using System.Data.Entity;

namespace OutdorAdvManage.Data
{
    public class OutdorAdvManageEntities : DbContext
    {
        public OutdorAdvManageEntities() : base("ManageEntities")
        {
        }

        public DbSet<AdvertisingConstruction> AdvertisingConstructions { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<IssuancePermit> IssuancePermits { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<Counterparty> Counterpartys { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new СounterpartyConfiguration());
            //modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}