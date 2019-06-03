using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVMovies.DAO
{
    public class Movies
    {
        [Key]
        public int ID { get; set; }
        public string refID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Rating { get; set; }
        public string Votes { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public System.DateTime LastUpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime DeletedTime { get; set; }
    }
}
