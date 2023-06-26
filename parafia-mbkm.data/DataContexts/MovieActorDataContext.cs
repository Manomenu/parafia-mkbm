using Microsoft.EntityFrameworkCore;
using parafia_mbkm.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parafia_mbkm.data.DataContexts
{
    public class MovieActorDataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public MovieActorDataContext(DbContextOptions<MovieActorDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
