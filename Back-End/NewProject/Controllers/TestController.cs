using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
       // [AllowAnonymous]
        [Authorize]
        public bool Author()
        {
            return true;
        }

       // [AllowAnonymous]
        [Authorize(Roles = "user")]
        public bool UserTest()
        {
            return true;
        }

       // [AllowAnonymous]
        [Authorize(Roles = "admin")]
        public bool AdminTest()
        {
            return true;
        }
    }
}



