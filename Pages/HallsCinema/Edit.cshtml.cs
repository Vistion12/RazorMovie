using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorMovie.Data;
using RazorMovie.Model;

namespace RazorMovie.Pages.HallsCinema
{
    public class EditModel : PageModel
    {
        private readonly RazorMovie.Data.MovieContext _context;

        public EditModel(RazorMovie.Data.MovieContext context)
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

            var hallcinema =  await _context.HallCinemas.FirstOrDefaultAsync(m => m.NumberHall == id);
            if (hallcinema == null)
            {
                return NotFound();
            }
            HallCinema = hallcinema;
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

            _context.Attach(HallCinema).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HallCinemaExists(HallCinema.NumberHall))
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

        private bool HallCinemaExists(int id)
        {
            return _context.HallCinemas.Any(e => e.NumberHall == id);
        }
    }
}
