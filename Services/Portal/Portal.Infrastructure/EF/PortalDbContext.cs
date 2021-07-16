using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.Infrastructure.EntityTypeConfigurations.TodoApp;
using System;
using Role = Portal.Domain.Aggregates.Auth.Role;
using User = Portal.Domain.Aggregates.Auth.User;

namespace Portal.Infrastructure.EF
{
    public class PortalDbContext : IdentityDbContext<User, Role, Guid>
    {
        public PortalDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TodoApp
            modelBuilder.ApplyConfiguration(new TaskTypeConfiguration());
        }
    }
}