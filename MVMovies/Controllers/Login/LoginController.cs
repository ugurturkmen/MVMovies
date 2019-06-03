using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVMovies.Controllers.Login
{
    [Route("api/Login/[controller]")]
    public class LoginController : Controller
    {
        DTO.AppSettings appSettings = new DTO.AppSettings();
        private readonly IConfiguration configuration;
        public LoginController(DAO.MVMoviesContext dbContext, IConfiguration iConfig)
        {
            configuration = iConfig;

            appSettings.dbContext = dbContext;
            appSettings.apiMoviesProviderName = configuration.GetValue<string>("AppSettings:apiMoviesProviderName");
            appSettings.dataCache = configuration.GetValue<string>("AppSettings:dataCache");
            appSettings.logConfigFile = configuration.GetValue<string>("AppSettings:logConfigFile");

        }


        [HttpGet]
        public int Get(string UserName, string Password)
        {
            BUS.Users bus_user = new BUS.Users(appSettings);
            DTO.Users _user = bus_user.loginUser(UserName, Password);

            if (_user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("UserName", _user.UserName),
                    new Claim("UserID",_user.ID.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);

                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
