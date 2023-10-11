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
                    Title = "Persona 5 Royal",
                    ReleaseDate = DateTime.Parse("2019-10-31"),
                    Genre = "RPG",
                    Rating = 95,
                    Platform = "PS4"
                },

                new Videogame
                {
                    Title = "The Legend of Zelda: Tears of the Kingdom",
                    ReleaseDate = DateTime.Parse("2023-5-12"),
                    Genre = "Action Adventure",
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
                    Title = "Super Mario Odyssey",
                    ReleaseDate = DateTime.Parse("2017-10-27"),
                    Genre = "Adventure",
                    Rating = 97,
                    Platform = "Nintendo Switch"
                },

                new Videogame
                {
                    Title = "The Legend of Zelda: Breath of the Wild",
                    ReleaseDate = DateTime.Parse("2017-3-17"),
                    Genre = "Action Adventure",
                    Rating = 97,
                    Platform = "Nintendo Switch"
                },

                new Videogame
                {
                    Title = "The Last of Us: Remastered",
                    ReleaseDate = DateTime.Parse("2014-07-14"),
                    Genre = "Adventure",
                    Rating = 95,
                    Platform = "PS4"
                },

                new Videogame
                {
                    Title = "Elden Ring",
                    ReleaseDate = DateTime.Parse("2022-02-25"),
                    Genre = "Action RPG",
                    Rating = 95,
                    Platform = "PC"
                },

                new Videogame
                {
                    Title = "Portal 2",
                    ReleaseDate = DateTime.Parse("2011-04-19"),
                    Genre = "Puzzle",
                    Rating = 95,
                    Platform = "PC"
                },

                new Videogame
                {
                    Title = "NieR: Automata",
                    ReleaseDate = DateTime.Parse("2017-03-07"),
                    Genre = "JRPG",
                    Rating = 88,
                    Platform = "PC"
                },

                new Videogame
                {
                    Title = "DOOM",
                    ReleaseDate = DateTime.Parse("2017-11-10"),
                    Genre = "Action",
                    Rating = 79,
                    Platform = "PC"
                }
            );
            context.SaveChanges();
        }
    }
}