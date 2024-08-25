using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorMovie.Data;
using RazorMovie.Model;

namespace RazorMovie.Pages.Shedules
{
    public class IndexModel : PageModel
    {
        private readonly RazorMovie.Data.MovieContext _context;

        public IndexModel(RazorMovie.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Shedule> Shedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Shedule = await _context.Shedules
                .Include(s => s.Movie) // таким образом добавили возможность визуализации названия фильма и номер зала
                .Include(s => s.HallCinema)    
                .ToListAsync();
        }
    }
}
