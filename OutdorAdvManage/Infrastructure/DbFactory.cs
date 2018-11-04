namespace OutdorAdvManage.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private OutdorAdvManageEntities dbContext;

        public OutdorAdvManageEntities Init()
        {
            return dbContext ?? (dbContext = new OutdorAdvManageEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}