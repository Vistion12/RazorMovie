using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorMovie.Data;
using RazorMovie.Model;

namespace RazorMovie.Pages.HallsCinema
{
    public class DeleteModel : PageModel
    {
        private readonly RazorMovie.Data.MovieContext _context;

        public DeleteModel(RazorMovie.Data.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HallCinema HallCinema { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallcinema = await _context.HallCinemas.FirstOrDefaultAsync(m => m.NumberHall == id);

            if (hallcinema == null)
            {
                return NotFound();
            }
            else
            {
                HallCinema = hallcinema;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hallcinema = await _context.HallCinemas.FindAsync(id);
            if (hallcinema != null)
            {
                HallCinema = hallcinema;
                _context.HallCinemas.Remove(HallCinema);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
