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
    public class UpdateAllMovies : Controller
    {
        DTO.AppSettings appSettings = new DTO.AppSettings();
        private readonly IConfiguration configuration;
        public UpdateAllMovies(DAO.MVMoviesContext dbContext, IConfiguration iConfig)
        {
            configuration = iConfig;

            appSettings.dbContext = dbContext;
            appSettings.apiMoviesProviderName = configuration.GetValue<string>("AppSettings:apiMoviesProviderName");
            appSettings.dataCache = configuration.GetValue<string>("AppSettings:dataCache");
            appSettings.logConfigFile = configuration.GetValue<string>("AppSettings:logConfigFile");

        }

        /// <summary>
        /// Dışarıdan gelen talep doğrultusunda Veritabanında ki bütün filmlerin api aracılığıyla güncellenmesini sağlıyor.
        /// </summary>
        [HttpGet]
        public void Get()
        {
            BUS.Movies bus_movies = new BUS.Movies(appSettings);
            bus_movies.updateAllMoviesFromApi();
        }

    }
}
