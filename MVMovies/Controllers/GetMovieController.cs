using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMovieController : Controller
    {
        DTO.AppSettings appSettings = new DTO.AppSettings();
        private readonly IConfiguration configuration;

        /// <summary>
        /// appSetting modelinin parametleri burada çekiliyor.
        /// </summary>
        public GetMovieController(DAO.MVMoviesContext dbContext, IConfiguration iConfig)
        {
            configuration = iConfig;

            appSettings.dbContext = dbContext;
            appSettings.apiMoviesProviderName = configuration.GetValue<string>("AppSettings:apiMoviesProviderName");
            appSettings.dataCache = configuration.GetValue<string>("AppSettings:dataCache");
            appSettings.logConfigFile = configuration.GetValue<string>("AppSettings:logConfigFile");

        }

        [HttpGet]
        public ActionResult<DTO.Movies> Get(string Title)
        {
            var movie = getMovie(Title);
            if (movie != null && movie.Title.Length > 0)
            {
                return Json(new
                {
                    statu = 1,
                    movie = movie
                });
            }
            else
            {
                return Json(new
                {
                    statu = 0,
                    description = "Movie is not found!"
                });
            }
        }

        [HttpPost]
        public ActionResult<DTO.Movies> Post(string Title)
        {
            var movie = getMovie(Title);
            if (movie != null && movie.Title.Length > 0)
            {
                return Json(new
                {
                    statu = 1,
                    movie = movie
                });
            }
            else
            {
                return Json(new
                {
                    statu = 0,
                    description = "Movie is not found!"
                });
            }
        }

        /// <summary>
        /// Dışarıdan alınan Title parametresini direk olarak BUS katmanına gönderiyor.
        /// </summary>
        private DTO.Movies getMovie(string Title)
        {

            BUS.Movies busMovies = new BUS.Movies(appSettings);
                DTO.Movies movie = busMovies.getMovie(Title);
            return movie;
        }
    }
}
