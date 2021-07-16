using Portal.Infrastructure.EF;
using TaskTable = Portal.Domain.Aggregates.TodoApp.Task;

namespace Portal.Infrastructure.Repositories.TodoApp
{
    public interface ITaskRepository : IRepository<TaskTable>
    {
    }

    public class TaskRepository : EfRepository<TaskTable>, ITaskRepository
    {
        public TaskRepository(PortalDbContext portalDbContext) : base(portalDbContext)
        {
        }
    }
}