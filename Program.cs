using Microsoft.EntityFrameworkCore;
using RazorMovie.Data;
using RazorMovie.Model;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

Configure(app, app.Environment);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<Order>();
    services.AddSingleton<Ticket>();
    services.AddSingleton<HallCinema>();
    services.AddSingleton<FormatedShedule>();    
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
        x.MapRazorPages();
        x.MapBlazorHub();
    });

}



