using FilmesApi2.Data;
using FilmesApi2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FilmesApi;

public class Startup
{
    public ConfigurationManager Configuration { get; }
    public IWebHostEnvironment Env { get; }

    public Startup(ConfigurationManager configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Env = env;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        Configuration
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Env.EnvironmentName}.json");

        var conectionString = Configuration.GetConnectionString("ContextConnection");

        services.AddDbContext<Context>(opts => opts.UseLazyLoadingProxies()
            .UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));

        AddAuthenticationServices(services);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<FilmeService, FilmeService>();
        services.AddScoped<CinemaService, CinemaService>();
        services.AddScoped<EnderecoService, EnderecoService>();
        services.AddScoped<SessaoService, SessaoService>();

        services.AddControllers().AddNewtonsoftJson();
    }

    private static void AddAuthenticationServices(IServiceCollection services)
    {
        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(token =>
        {
            token.RequireHttpsMetadata = false;
            token.SaveToken = true;
            token.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
        if (Env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}