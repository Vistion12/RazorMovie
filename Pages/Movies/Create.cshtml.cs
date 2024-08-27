using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorMovie.Data;
using RazorMovie.Model;
using RazorMovie.Services.Interfaces;
using RazorMovie.ViewModel;

namespace RazorMovie.Pages.Movies;

public class CreateModel(MovieContext context, IPhotoService photoService) : PageModel
{   
    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public MovieViewModel movieViewModel { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || movieViewModel.URL is null)
        {
            return Page();
        }

        var resultAddPhotoASync = await photoService.AddPhotoAsync(movieViewModel.URL);

        var movie = new Movie
        {
            Title = movieViewModel.Title,
            Description = movieViewModel.Description,
            Duration = default(TimeSpan),
            URL= resultAddPhotoASync.Url.ToString(),
        };

        context.Movies.Add(movie);
        await context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
