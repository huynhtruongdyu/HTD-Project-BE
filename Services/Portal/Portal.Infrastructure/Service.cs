using Portal.Infrastructure.Services.Auth;
using Portal.Infrastructure.Services.TodoApp;

namespace Portal.Infrastructure
{
    public interface IService
    {
        public IUserService UserService { get; }

        //TodoApp
        public ITaskService TaskService { get; }
    }

    public class Service : IService
    {
        public IUserService UserService { get; }

        public ITaskService TaskService { get; }

        public Service(
            IUserService userService,
            ITaskService taskService)
        {
            UserService = userService;
            TaskService = taskService;
        }
    }
}