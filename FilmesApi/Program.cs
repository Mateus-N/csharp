using FilmesApi;
using FilmesApi2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration, builder.Environment);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;

	var context = services.GetRequiredService<Context>();
	if (context.Database.GetPendingMigrations().Any())
	{
		context.Database.Migrate();
	}
}

startup.Configure(app);

app.Run();
