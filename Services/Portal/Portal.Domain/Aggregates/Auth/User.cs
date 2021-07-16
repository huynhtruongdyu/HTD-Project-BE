using Microsoft.AspNetCore.Identity;
using System;

namespace Portal.Domain.Aggregates.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname => $"{Firstname} {Lastname}";
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public User() : base()
        {
            CreatedDate = DateTime.Now;
        }
    }
}