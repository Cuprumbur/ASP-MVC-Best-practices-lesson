using System;

namespace OutdorAdvManage.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        OutdorAdvManageEntities Init();
    }
}