using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;

namespace RazorPagesMusic.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))
        {
            if (context == null || context.Music == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Music.Any())
            {
                return;   // DB has been seeded
            }

            context.Music.AddRange(
                new Music
                {
                    Title = "Fire",
                    ReleaseDate = DateTime.Parse("2023-5-5"),
                    Genre = "Rock",
                    Length = 3.21M,
                    Rating = 5
                },

                new Music
                {
                    Title = "I Can See You",
                    ReleaseDate = DateTime.Parse("2023-7-7"),
                    Genre = "Pop",
                    Length = 5.07M
                }
            );
            context.SaveChanges();
        }
    }
}