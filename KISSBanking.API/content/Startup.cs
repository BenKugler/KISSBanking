using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KISSBanking.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddMvc()
          .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
      {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
      }));

      // Simple example with dependency injection for a data provider.
      services.AddSingleton<Providers.IUserProvider, Providers.UserProvider>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();

        // Webpack initialization with hot-reload.
        app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
        {
          HotModuleReplacement = true,
        });
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();
      app.UseCors("MyPolicy");
      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");

        routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "Home", action = "Index" });
      });
    }
  }
}
