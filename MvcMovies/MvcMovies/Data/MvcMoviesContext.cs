using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovies.Models;

namespace MvcMovies.Data
{
    public class MvcMoviesContext : DbContext
    {
        public MvcMoviesContext (DbContextOptions<MvcMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovies.Models.Movie> Movie { get; set; } = default!;
    }
}
