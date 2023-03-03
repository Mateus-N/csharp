using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi;

public class Startup
{
	public IConfiguration Configuration { get; }
	
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddDbContext<UserDbContext>(options =>
			options.UseMySQL(Configuration.GetConnectionString("UsuarioConnection")));
		services.AddIdentity<Usuario, IdentityRole<int>>(
			opt => opt.SignIn.RequireConfirmedEmail = true
			)
			.AddEntityFrameworkStores<UserDbContext>()
			.AddDefaultTokenProviders();

		services.AddScoped<CadastroService, CadastroService>();
		services.AddScoped<LoginService, LoginService>();
		services.AddScoped<TokenService, TokenService>();
		services.AddScoped<LogoutService, LogoutService>();
		services.AddScoped<SendEmailService, SendEmailService>();
		services.AddScoped<HttpClient, HttpClient>();
		
		services.AddControllers();
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseHttpsRedirection();

		app.UseRouting();

		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});
	}
}
