using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain.Aggregates.Auth;
using Portal.Infrastructure;
using System;

namespace Portal.API.Controllers
{
    public class CommonController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IService _service;

        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public CommonController(
            IUnitOfWork unitOfWork,
            IService service)
        {
            _unitOfWork = unitOfWork;
            _service = service;
        }

        [HttpPost("init-db")]
        [AllowAnonymous]
        public IActionResult InitDb()
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
            _service.UserService.Create(userAdmin);
            return SuccessResult("Ok");
        }
    }
}