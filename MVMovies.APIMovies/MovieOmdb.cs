using System;
using System.Collections.Generic;
using System.Text;
using MVMovies.DTO;
using Newtonsoft.Json;

namespace MVMovies.APIMovies
{
    public class MovieOmdb : IMovie
    {
        /// <summary>
        /// Gelen parametreyi apiye gönderiyoruz ve dönen Json veriyi Modelimize Deserialize ediyoruz.
        /// </summary>
        public Movies getMovie(DTO.AppSettings appSettings, string Title)
        {
            DTO.Movies movie = null;

            try
            {
                string url = "http://www.omdbapi.com/?t=" + Title + "&apikey=31aaac41";

                Helper hp = new Helper();
                string jsonData = hp.urlGetResponse(url);

                if (!jsonData.Contains("Movie not found!"))
                {
                    movie = JsonConvert.DeserializeObject<DTO.Movies>(jsonData.Replace("imdbID", "refID").Replace("imdbRating", "Rating").Replace("imdbVotes", "Votes"));
                }
            }
            catch (Exception ex)
            {
                LogManagement.ILogger logger = new LogManagement.Logger();
                logger.add(appSettings.logConfigFile, "Error:" + ex.InnerException);
            }
            

            return movie;
        }

        public Movies getMovieByRefID(AppSettings appSettings, string refID)
        {
            DTO.Movies movie = null;

            try
            {
                string url = "http://www.omdbapi.com/?i=" + refID+ "&apikey=31aaac41";

                Helper hp = new Helper();
                string jsonData = hp.urlGetResponse(url);

                if (!jsonData.Contains("Movie not found!"))
                {
                    movie = JsonConvert.DeserializeObject<DTO.Movies>(jsonData.Replace("imdbID", "refID").Replace("imdbRating", "Rating").Replace("imdbVotes", "Votes"));
                }
            }
            catch (Exception ex)
            {
                LogManagement.ILogger logger = new LogManagement.Logger();
                logger.add(appSettings.logConfigFile, "Error:" + ex.InnerException);
            }


            return movie;
        }
    }
}
