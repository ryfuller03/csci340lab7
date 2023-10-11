using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using RazorPagesVideogame.Data;

namespace RazorPagesMovie.Pages.Videogames
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesVideogame.Data.RazorPagesVideogameContext _context;

        public IndexModel(RazorPagesVideogame.Data.RazorPagesVideogameContext context)
        {
            _context = context;
        }

        public IList<Videogame> Videogame { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Videogame != null)
            {
                Videogame = await _context.Videogame.ToListAsync();
            }
        }
    }
}
