using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.DTO
{
    public class AppSettings
    {
        public DAO.MVMoviesContext dbContext { get; set; }
        public string apiMoviesProviderName { get; set; }
        public string dataCache { get; set; }
        public string logConfigFile { get; set; }
    }
}
