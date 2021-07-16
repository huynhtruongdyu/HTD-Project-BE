using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskTable = Portal.Domain.Aggregates.TodoApp.Task;

namespace Portal.Infrastructure.EntityTypeConfigurations.TodoApp
{
    public class TaskTypeConfiguration : IEntityTypeConfiguration<TaskTable>
    {
        public void Configure(EntityTypeBuilder<TaskTable> builder)
        {
            builder.ToTable(nameof(TaskTable));
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Name).IsRequired();
            builder.Property(task => task.Priority).IsRequired();
            builder.Property(task => task.Status).IsRequired();
        }
    }
}