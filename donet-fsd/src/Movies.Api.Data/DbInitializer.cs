using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Movies.Model;

namespace Movies.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MoviesContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
            new Movie{Title="The Terminal",Description="CommercialMovie",ReleaseDate=DateTime.Parse("2005-09-01"),Director="James Cameron", Cast="Tom Hanks",Genre ="Drama"},
            new Movie{Title="Moonram Priai",Description="CommercialMovie",ReleaseDate=DateTime.Parse("2005-09-01"),Director="James Cameron", Cast="Tom Hanks",Genre ="Drama"},

            };
            foreach (Movie s in movies)
            {
                context.Movies.Add(s);
            }
            context.SaveChanges();

           
        }
    }
}
