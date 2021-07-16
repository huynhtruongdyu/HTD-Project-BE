using Portal.Domain.Enums.TodoApp;

namespace Portal.Domain.Aggregates.TodoApp
{
    public class Task : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}