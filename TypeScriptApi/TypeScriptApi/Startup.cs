using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TypeScriptApi.Data;
using TypeScriptApi.Services;

namespace TypeScriptApi;

public class Startup
{
    public IConfiguration Configuration { get; set; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Configuration
            .GetConnectionString("ContextConnection")!;

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySQL(connectionString);
        });

        AddServicesInjetables(services);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    public void AddServicesInjetables(IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type interfaceType = typeof(IInjetable);

        var classesImplementandoInterface = assembly.GetTypes()
            .Where(t => interfaceType.IsAssignableFrom(t) && !t.IsInterface)
            .ToList();

        foreach (var classType in classesImplementandoInterface)
        {
            var interfaceTypes = classType.GetInterfaces()
                .First(i => i.Name == $"I{classType.Name}");

            services.AddScoped(interfaceTypes, classType);
        }
    }
}
