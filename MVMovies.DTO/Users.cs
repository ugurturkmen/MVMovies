using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.DTO
{
    public class Users
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime DeletedTime { get; set; }
    }
}
