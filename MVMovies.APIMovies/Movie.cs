using System;
using System.Collections.Generic;
using System.Text;
using MVMovies.DTO;

namespace MVMovies.APIMovies
{
    public class Movie : IMovie
    {
        DTO.Movies movie = new Movies();
        IMovie _Movie;

        /// <summary>
        /// appSetting den gelen ProviderName aracılığı ile hangi apinin kullanılacağını belirliyoruz.
        /// Böylelikle (Loosely Coupled) bir yapı oluşturulmuş oluyor.
        /// </summary>
        public Movies getMovie(DTO.AppSettings appSettings, string Title)
        {
            if (appSettings.apiMoviesProviderName == "OMDB")
            {
                _Movie = new MovieOmdb();
            }
            movie = _Movie.getMovie(appSettings, Title);
            return movie;
        }

        public Movies getMovieByRefID(AppSettings appSettings, string refID)
        {
            if (appSettings.apiMoviesProviderName == "OMDB")
            {
                _Movie = new MovieOmdb();
            }
            movie = _Movie.getMovieByRefID(appSettings, refID);
            return movie;
        }
    }
}
