using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task OnGetAsync()
        {
            if (_context.Music != null)
            {
                Music = await _context.Music.ToListAsync();
            }
        }
    }
}
