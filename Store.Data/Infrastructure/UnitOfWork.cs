namespace Store.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private StoreEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public StoreEntities DbContext
        {
            get { return dbContext ?? (dbContext = new StoreEntities()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}