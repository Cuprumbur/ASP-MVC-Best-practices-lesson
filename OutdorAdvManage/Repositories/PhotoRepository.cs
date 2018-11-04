using OutdorAdvManage.Data.Infrastructure;
using OutdorAdvManage.Model.Models;

namespace OutdorAdvManage.Data.Repositories
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository
    {
        public PhotoRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public override void Update(Photo entity)
        {
            base.Update(entity);
        }
    }

    public interface IPhotoRepository : IRepository<Photo>
    {
    }
}