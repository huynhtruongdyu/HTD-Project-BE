using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Aggregates.Auth
{
    public class Role : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
