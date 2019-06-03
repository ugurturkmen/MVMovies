using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVMovies.Controllers.CacheManagement
{
    [Route("api/CacheManagement/[controller]")]
    public class ClearController : Controller
    {
        DTO.AppSettings appSettings = new DTO.AppSettings();
        private readonly IConfiguration configuration;
        public ClearController(DAO.MVMoviesContext dbContext, IConfiguration iConfig)
        {
            configuration = iConfig;

            appSettings.dbContext = dbContext;
            appSettings.apiMoviesProviderName = configuration.GetValue<string>("AppSettings:apiMoviesProviderName");
            appSettings.dataCache = configuration.GetValue<string>("AppSettings:dataCache");
            appSettings.logConfigFile = configuration.GetValue<string>("AppSettings:logConfigFile");

        }


        /// <summary>
        /// Tüm cache verilerini temizliyor.
        /// </summary>
        [HttpGet]
        public void Get()
        {
            DataCache.ICacheManager cacheManager = new DataCache.CacheManager(appSettings.dataCache);
            cacheManager.clear();
        }

   
    }
}
