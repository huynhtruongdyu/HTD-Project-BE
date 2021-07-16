using Microsoft.EntityFrameworkCore;
using Portal.Infrastructure.EF;
using Portal.Infrastructure.Repositories.TodoApp;
using System;

namespace Portal.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        #region Repositories

        #region TodoApp
        public ITaskRepository TaskRepository { get; }
        #endregion

        #endregion Repositories
    }

    public class UnitOfWork : IUnitOfWork
    {

        public DbContext Context { get; }

        #region Repositories
        public ITaskRepository TaskRepository { get; }
        #endregion

        public UnitOfWork(
            PortalDbContext portalDbContext,
            ITaskRepository taskRepository)
        {
            Context = portalDbContext;

            #region Repositories
            TaskRepository = taskRepository;
            #endregion
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