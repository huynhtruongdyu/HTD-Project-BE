using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Portal.Infrastructure.EF
{
    public class PortalDbContextDesignFactory : IDesignTimeDbContextFactory<PortalDbContext>
    {
        public PortalDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=127.0.0.1;Port=5432;Database=htd-dev;User Id=admin;Password=root;";
            //var connectionString = "Host:localhost;Port:5432;Database:ta-studo-dev;Username:admin;Password:root";
            var optionsBuilder = new DbContextOptionsBuilder<PortalDbContext>()
                .UseNpgsql(connectionString);

            return new PortalDbContext(optionsBuilder.Options);
        }
    }
}