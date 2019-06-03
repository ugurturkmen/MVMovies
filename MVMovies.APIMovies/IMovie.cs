using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.APIMovies
{
    public interface IMovie
    {
        DTO.Movies getMovie(DTO.AppSettings appSettings, string Title);

        DTO.Movies getMovieByRefID(DTO.AppSettings appSettings, string refID);
    }
}
