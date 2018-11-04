namespace OutdorAdvManage.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private OutdorAdvManageEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public OutdorAdvManageEntities DbContext
        {
            get { return dbContext ?? (dbContext = new OutdorAdvManageEntities()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}