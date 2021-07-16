using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Portal.Domain.Aggregates.Auth;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Infrastructure.EF
{
    public class PortalDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async Task SeedAsync(PortalDbContext context, ILogger<PortalDbContextSeed> looger)
        {
            if (!context.Users.Any())
            {
                var userAdmin = new User
                {
                    Id = Guid.NewGuid(),

                    Firstname = "Super",
                    Lastname = "Admin",

                    UserName = "admin",
                    NormalizedUserName = "ADMIN",

                    Email = "htd27432390@gmail.com",
                    NormalizedEmail = "HTD27432390@GMAIL.COM",

                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                userAdmin.PasswordHash = _passwordHasher.HashPassword(userAdmin, "Abc@1234");
                context.Users.Add(userAdmin);
            }
            await context.SaveChangesAsync();
        }
    }
}