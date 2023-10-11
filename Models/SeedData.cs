using Microsoft.EntityFrameworkCore;
using RazorPagesVideogame.Data;

namespace RazorPagesMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesVideogameContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesVideogameContext>>()))
        {
            if (context == null || context.Videogame == null)
            {
                throw new ArgumentNullException("Null RazorPagesVideogameContext");
            }

            // Look for any movies.
            if (context.Videogame.Any())
            {
                return;   // DB has been seeded
            }

            context.Videogame.AddRange(
                new Videogame
                {
                    Title = "The Legend of Zelda: Breath of the Wild",
                    ReleaseDate = DateTime.Parse("2017-3-17"),
                    Genre = "Adventure",
                    Rating = 97,
                    Platform = "Nintendo Switch"
                },

                new Videogame
                {
                    Title = "The Legend of Zelda: Tears of the Kingdom",
                    ReleaseDate = DateTime.Parse("2023-5-12"),
                    Genre = "Adventure",
                    Rating = 96,
                    Platform = "Nintendo Switch"
                },

                new Videogame
                {
                    Title = "Minecraft",
                    ReleaseDate = DateTime.Parse("2011-11-18"),
                    Genre = "Sandbox",
                    Rating = 82,
                    Platform = "PC"
                },

                new Videogame
                {
                    Title = "Persona 5 Royal",
                    ReleaseDate = DateTime.Parse("2019-10-31"),
                    Genre = "RPG",
                    Rating = 95,
                    Platform = "PS4"
                }
            );
            context.SaveChanges();
        }
    }
}