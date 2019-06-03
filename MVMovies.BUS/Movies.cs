using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MVMovies.BUS
{
    public class Movies
    {
        private readonly DTO.AppSettings _appSettings;
        LogManagement.ILogger _logger = new LogManagement.Logger();

        public Movies(DTO.AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Dışarıdan aldığı parametre değerini önce cache de arıyor.
        /// Bulamazsa eğer veritabanına bakıyor.
        /// Veritabanında da yoksa APIMovies katmanı aracılığıyla apiden çekiyor.
        /// Movie bulunduğu zaman cache tekrar set ediliyor.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public DTO.Movies getMovie(string title)
        {
            DTO.Movies movie;
            try
            {

                DataCache.ICacheManager cacheManager = new DataCache.CacheManager(_appSettings.dataCache);
                movie = cacheManager.get("Movie_" + title);


                if (movie == null || movie.refID == null)
                {
                    movie = (from a in _appSettings.dbContext.Movies
                             where a.IsDeleted == false && a.Title.Contains(title)
                             select new DTO.Movies()
                             {
                                 ID = a.ID,
                                 refID = a.refID,
                                 Title = a.Title,
                                 Year = a.Year,
                                 Rated = a.Rated,
                                 Rating = a.Rating,
                                 Votes = a.Votes,
                                 Released = a.Released,
                                 Runtime = a.Runtime,
                                 Director = a.Director,
                                 Writer = a.Writer,
                                 Actors = a.Actors,
                                 Plot = a.Plot,
                                 Language = a.Language,
                                 Country = a.Country,
                                 Awards = a.Awards,
                                 Poster = a.Poster,
                                 LastUpdateTime = a.LastUpdateTime,
                             }).FirstOrDefault();

                    if (movie != null)
                    {
                        cacheManager.set("Movie_" + title, movie, 12);
                    }

                }

                if (movie == null || movie.refID == null)
                {
                    APIMovies.IMovie apiMovie = new APIMovies.Movie();
                    movie = apiMovie.getMovie(_appSettings, title);


                    if (movie != null)
                    {

                        #region Add Movie

                        DAO.Movies newmovie = new DAO.Movies();
                        newmovie.refID = movie.refID;
                        newmovie.Title = movie.Title;
                        newmovie.Year = movie.Year;
                        newmovie.Rated = movie.Rated;
                        newmovie.Rating = movie.Rating;
                        newmovie.Votes = movie.Votes;
                        newmovie.Released = movie.Released;
                        newmovie.Runtime = movie.Runtime;
                        newmovie.Director = movie.Director;
                        newmovie.Writer = movie.Writer;
                        newmovie.Actors = movie.Actors;
                        newmovie.Plot = movie.Plot;
                        newmovie.Language = movie.Language;
                        newmovie.Country = movie.Country;
                        newmovie.Awards = movie.Awards;
                        newmovie.Poster = movie.Poster;
                        newmovie.LastUpdateTime = DateTime.Now;
                        newmovie.DeletedTime = DateTime.Now;
                        _appSettings.dbContext.Movies.Add(newmovie);
                        _appSettings.dbContext.SaveChanges();

                        #endregion

                        cacheManager.set("Movie_" + title, movie, 12);
                    }
                }

                return movie;
            }
            catch (Exception ex)
            {
                _logger.add(_appSettings.logConfigFile, "Error:" + ex.InnerException);

                return new DTO.Movies();
            }
        }


        /// <summary>
        /// Gelen talep doğrultusunda veritabanındaki Filmler listeye alınıyor.
        /// Listeye alınan filmlerin güncel bilgileri APIMovies den gelen bilgiler ile güncelleniyor. 
        /// </summary>
        public void updateAllMoviesFromApi()
        {
            try
            {
                List<DAO.Movies> listMovies = (from a in _appSettings.dbContext.Movies
                                               where a.IsDeleted == false
                                               select a).ToList();

                APIMovies.IMovie apiMovie = new APIMovies.Movie();

                foreach (var item in listMovies)
                {
                    try
                    {
                        DTO.Movies dtoMovie = apiMovie.getMovieByRefID(_appSettings, item.refID);

                        item.Title = dtoMovie.Title;
                        item.Year = dtoMovie.Year;
                        item.Rated = dtoMovie.Rated;
                        item.Rating = dtoMovie.Rating;
                        item.Votes = dtoMovie.Votes;
                        item.Released = dtoMovie.Released;
                        item.Runtime = dtoMovie.Runtime;
                        item.Director = dtoMovie.Director;
                        item.Writer = dtoMovie.Writer;
                        item.Actors = dtoMovie.Actors;
                        item.Plot = dtoMovie.Plot;
                        item.Language = dtoMovie.Language;
                        item.Country = dtoMovie.Country;
                        item.Awards = dtoMovie.Awards;
                        item.Poster = dtoMovie.Poster;
                        item.LastUpdateTime = DateTime.Now;
                    }
                    catch (Exception ex)
                    {
                        _logger.add(_appSettings.logConfigFile, "Error:" + ex.InnerException);
                    }

                }
                _appSettings.dbContext.SaveChanges();


            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
