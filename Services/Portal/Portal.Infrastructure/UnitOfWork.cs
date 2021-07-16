using Microsoft.EntityFrameworkCore;
using Portal.Infrastructure.EF;
using System;

namespace Portal.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        #region Repositories

        //public IUserRepository UserRepository { get; }

        #endregion Repositories
    }

    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(
            PortalDbContext portalDbContext)
        {
            Context = portalDbContext;
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public void SaveChanges()
        {
            Context?.SaveChanges();
        }
    }
}