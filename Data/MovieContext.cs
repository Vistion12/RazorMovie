using Microsoft.EntityFrameworkCore;
using RazorMovie.Model;

namespace RazorMovie.Data
{
	public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
	{
		public DbSet<Movie> Movies { get; set; }
		public DbSet<HallCinema>HallCinemas { get; set; }
		public DbSet<Shedule> Shedules { get; set; }
	}
}


