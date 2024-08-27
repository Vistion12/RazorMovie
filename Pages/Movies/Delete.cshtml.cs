using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorMovie.Data;
using RazorMovie.Model;
using RazorMovie.Services;
using RazorMovie.Services.Interfaces;

namespace RazorMovie.Pages.Movies;

public class DeleteModel(MovieContext context, IPhotoService photoService) : PageModel
{
    

    [BindProperty]
    public Movie Movie { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

        if (movie == null)
        {
            return NotFound();
        }
        else
        {
            Movie = movie;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await context.Movies.FindAsync(id);
        if (movie != null)
        {
            Movie = movie;           
            context.Movies.Remove(Movie);
            await context.SaveChangesAsync();
            await photoService.DeletePhotoAsync(movie.URL);
        }

        return RedirectToPage("./Index");
    }
}
