using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVMovies.DAO
{
    public class MVMoviesContext : DbContext
    {
        public MVMoviesContext(DbContextOptions<MVMoviesContext> options) : base(options)
        {

        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
