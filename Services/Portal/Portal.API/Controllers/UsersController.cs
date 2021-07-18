using Microsoft.AspNetCore.Mvc;
using Portal.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.API.Controllers
{
    public class UsersController:BaseController
    {
        private readonly IService _service;

        public UsersController(
            IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return SuccessResult(_service.UserService.GetAll());
        }
    }
}
