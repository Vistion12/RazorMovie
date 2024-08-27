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
using RazorMovie.Services;
using RazorMovie.Services.Interfaces;
using RazorMovie.ViewModel;

namespace RazorMovie.Pages.Movies;

public class EditModel(MovieContext context, IPhotoService photoService) : PageModel
{


    [BindProperty]
    public MovieViewModel movieViewModel { get; set; } = default!;

    public Movie? Movie {  get; set; }

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
        Movie = movie;

        movieViewModel = new MovieViewModel
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            Duration = movie.Duration,
            URL = null,
        };

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
        var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieViewModel.Id);

        

        if (movieViewModel.URL is not null)
        {
            await photoService.DeletePhotoAsync(movie.URL);
            var ResultAddPhoto = await photoService.AddPhotoAsync(movieViewModel.URL);
            movie.URL = ResultAddPhoto.Url.ToString();
        }    

        movie.Title = movieViewModel.Title;
        movie.Description = movieViewModel.Description;
        movie.Duration = movieViewModel.Duration;
        
        await context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }


}
