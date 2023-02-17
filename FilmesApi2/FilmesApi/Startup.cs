using FilmesApi2.Data;
using FilmesApi2.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
		var conectionString = Configuration.GetConnectionString("ContextConnection");
		
		services.AddDbContext<Context>(opts => opts.UseLazyLoadingProxies()
			.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));
			
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		
		services.AddScoped<FilmeService, FilmeService>();
		services.AddScoped<CinemaService, CinemaService>();
		services.AddScoped<EnderecoService, EnderecoService>();
		services.AddScoped<SessaoService, SessaoService>();
		
		services.AddControllers().AddNewtonsoftJson();
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "teste", Version = "v1" });
		});
	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "teste v1"));
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
