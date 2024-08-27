using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorMovie.Model;

namespace RazorMovie.Data;

public class MovieContext(DbContextOptions<MovieContext> options) : IdentityDbContext(options)
{
	public DbSet<User> Users {  get; set; }
	public DbSet<Movie> Movies { get; set; }
	public DbSet<HallCinema>HallCinemas { get; set; }
	public DbSet<Shedule> Shedules { get; set; }
}


