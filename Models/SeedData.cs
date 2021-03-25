using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    //seed data to initially populate the database
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MoviesDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MoviesDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(


                    new Movie
                    {
                        category = "Action Thriller",
                        title = "Spy Games",
                        year = 1999,
                        director = "James Smith",
                        rating = "R",
                        edited = "No",
                        lent = "John Smith",
                        notes = "Movie was awesome"

                    }

                );

                context.SaveChanges();
            }
        }
    }
}


