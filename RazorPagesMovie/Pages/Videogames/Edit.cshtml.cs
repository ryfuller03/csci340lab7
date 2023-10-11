using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using RazorPagesVideogame.Data;

namespace RazorPagesMovie.Pages.Videogames
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesVideogame.Data.RazorPagesVideogameContext _context;

        public EditModel(RazorPagesVideogame.Data.RazorPagesVideogameContext context)
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

            var videogame =  await _context.Videogame.FirstOrDefaultAsync(m => m.id == id);
            if (videogame == null)
            {
                return NotFound();
            }
            Videogame = videogame;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Videogame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideogameExists(Videogame.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VideogameExists(int id)
        {
          return (_context.Videogame?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
