using Microsoft.EntityFrameworkCore;
using parafia_mbkm.data;
using parafia_mbkm.data.Models;

namespace parafia_mbkm
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ParafiaDbDataContext>();
            context.Database.EnsureCreated();
            AddMovies(context);
        }

        public static void AddMovies(ParafiaDbDataContext context)
        {
            if (context.Articles.Count() >= 10)
                context.Articles.Remove(context.Articles.First());
            Random rnd = new Random();
            Dictionary<int, string> content = new Dictionary<int, string>
            {
                {0, "Czy ziemia jest płaska? \nPłaska? \nAle jak? \nZiemia jest kulą odporna. \n"},
                {1, "Przepraszam bardzo, ja nie jestem pjakiem. \n Proszę po mnie nie jechać teraz. \n" },
                {2, "Szlachetne zdrowie, kto może Cię poznać? \n Kto zapomni ten się nie upomni. \n"},
                {3, "Janek to nie była moja wina. \n To kto go pobił? \n Sam się pobił! \n" }
            };
            context.Articles.Add(new Article
            {
                Header = $"Prośba o zebranie numer {rnd.Next(1, 100)}\n",
                Content = content[rnd.Next(0, 3)]
            });

            context.SaveChanges();
        }
    }
}
