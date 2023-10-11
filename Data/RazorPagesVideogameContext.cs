using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesVideogame.Data
{
    public class RazorPagesVideogameContext : DbContext
    {
        public RazorPagesVideogameContext (DbContextOptions<RazorPagesVideogameContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Videogame> Videogame { get; set; } = default!;
    }
}
