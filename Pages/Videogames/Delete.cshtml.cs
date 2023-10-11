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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesVideogame.Data.RazorPagesVideogameContext _context;

        public DeleteModel(RazorPagesVideogame.Data.RazorPagesVideogameContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Videogame Videogame { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Videogame == null)
            {
                return NotFound();
            }

            var videogame = await _context.Videogame.FirstOrDefaultAsync(m => m.id == id);

            if (videogame == null)
            {
                return NotFound();
            }
            else 
            {
                Videogame = videogame;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Videogame == null)
            {
                return NotFound();
            }
            var videogame = await _context.Videogame.FindAsync(id);

            if (videogame != null)
            {
                Videogame = videogame;
                _context.Videogame.Remove(Videogame);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
