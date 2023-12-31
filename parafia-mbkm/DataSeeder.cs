﻿using parafia_mbkm.data;
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
            AddContacts(context);

        }

        private static void AddMovies(ParafiaDbDataContext context)
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
        private static void AddContacts(ParafiaDbDataContext context)
        {
            if (context.Contacts.FirstOrDefault() != null) return;

            context.Contacts.Add(new Contact
            {
                ContactTitle = "Proboszcz",
                ContactLines = new List<ContactLine>
                {
                    new ContactLine { Category = "Numer telefonu", Value = "333333222", Icon = "phone" },
                    new ContactLine { Category = "Email", Value = "abba@wp.pl", Icon = "mail" }
                }
            });
            context.Contacts.Add(new Contact
            {
                ContactTitle = "Organista",
                ContactLines = new List<ContactLine>
                {
                    new ContactLine { Category = "Numer telefonu", Value = "543111222", Icon = "phone" },
                    new ContactLine { Category = "Email", Value = "haha@onet.pl", Icon = "mail" }
                }
            });
            context.SaveChanges();
        }
    }
}
