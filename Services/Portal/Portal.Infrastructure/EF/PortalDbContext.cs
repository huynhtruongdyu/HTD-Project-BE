using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User = Portal.Domain.Aggregates.Auth.User;
using Role = Portal.Domain.Aggregates.Auth.Role;
using Microsoft.EntityFrameworkCore;

namespace Portal.Infrastructure.EF
{
    public class PortalDbContext:IdentityDbContext<User, Role, Guid>
    {
        public PortalDbContext(DbContextOptions options):base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        //}
    }
}
