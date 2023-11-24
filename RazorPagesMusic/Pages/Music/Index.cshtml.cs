using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;

namespace RazorPagesMusic.Pages_Music
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMusic.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Music> Music { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MusicGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Music
                                            orderby m.Genre
                                            select m.Genre;

            var music = from m in _context.Music
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                music = music.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MusicGenre))
            {
                music = music.Where(x => x.Genre == MusicGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Music = await music.ToListAsync();
        }
    }
}
