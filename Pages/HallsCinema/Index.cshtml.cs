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
    public class IndexModel : PageModel
    {
        private readonly RazorMovie.Data.MovieContext _context;

        public IndexModel(RazorMovie.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<HallCinema> HallCinema { get;set; } = default!;

        public async Task OnGetAsync()
        {
            HallCinema = await _context.HallCinemas.ToListAsync();
        }
    }
}
