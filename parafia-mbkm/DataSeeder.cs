using parafia_mbkm.data.DataContexts;
using parafia_mbkm.data.Models;

namespace parafia_mbkm
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<MovieActorDataContext>();
            context.Database.EnsureCreated();
            AddMovies(context);
        }

        public static void AddMovies(MovieActorDataContext context)
        {
            var movie = context.Movies.FirstOrDefault();
            //if (movie == null) return;

            context.Movies.Add(new Movie
            {
                Title = "Rambo",
                Actors = new List<Actor>
                {
                    new Actor { Name = "Adasko"},
                    new Actor { Name = "Rafalko"}
                }
            });

            context.SaveChanges();
        }
    }
}
