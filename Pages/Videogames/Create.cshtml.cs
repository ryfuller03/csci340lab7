using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;
using RazorPagesVideogame.Data;

namespace RazorPagesMovie.Pages.Videogames
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesVideogame.Data.RazorPagesVideogameContext _context;

        public CreateModel(RazorPagesVideogame.Data.RazorPagesVideogameContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Videogame Videogame { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Videogame == null || Videogame == null)
            {
                return Page();
            }

            _context.Videogame.Add(Videogame);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
