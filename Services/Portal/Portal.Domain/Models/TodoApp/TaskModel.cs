using Portal.Domain.Enums.TodoApp;
using System;

namespace Portal.Domain.Models.TodoApp
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class TaskCreateReqModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
    }

    public class TaskUpdateReqModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
    }
}