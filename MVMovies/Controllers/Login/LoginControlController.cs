using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVMovies.Controllers.Login
{
    [Route("api/Login/[controller]")]
    public class LoginControlController : Controller
    {
        [HttpGet]
        public string Get()
        {
            var name = User.Claims.Where(c => c.Type == "UserName")
               .Select(c => c.Value).SingleOrDefault();

            if (name != null)
            {
                return name;
            }
            else
            {
                return "0";
            }
        }
    }
}
