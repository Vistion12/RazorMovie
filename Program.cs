using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorMovie.Core;
using RazorMovie.Data;
using RazorMovie.Model;
using RazorMovie.Services;
using RazorMovie.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

await Seed.SeedUserAndRolesAsync(app);

Configure(app, app.Environment);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<Order>();
    services.AddSingleton<Ticket>();
    services.AddSingleton<HallCinema>();
    services.AddSingleton<FormatedShedule>();

	services.AddScoped<IPhotoService, PhotoService>();
   services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

	services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<MovieContext>();
	services.AddMemoryCache();
	services.AddSession();
	services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


    services.AddDbContext<MovieContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext") ??
		throw new InvalidOperationException("Connection string 'MovieContext' not found.")));

    services.AddServerSideBlazor();
    services.AddRazorPages();
}
void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
	if (!env.IsDevelopment())
	{
		app.UseExceptionHandler("/Error");
		app.UseHsts();
	}
	app.UseHttpsRedirection();
	
	app.UseStaticFiles();

	app.UseRouting();
	app.UseEndpoints(x =>
	{
		x.MapBlazorHub();
		x.MapRazorPages();
       
    });

}



