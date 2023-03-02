using Agenda.Data;
using Microsoft.EntityFrameworkCore;

namespace Agenda;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Configuration.GetConnectionString("ContextConnection");

        services.AddDbContext<AgendaContext>(opts => opts
            .UseLazyLoadingProxies()
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
        ));

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddControllers();
    }

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
