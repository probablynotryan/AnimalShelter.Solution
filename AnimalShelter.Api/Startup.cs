using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AnimalShelterApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace AnimalShelterApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
  
    public IConfiguration Configuration {get;}

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AnimalShelterApiContext>(opt =>
        opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
      
      services.AddCors(options => options
          .AddPolicy("CorsPolicy", builder => builder
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
          )
      );

      services.AddSwaggerGen(c =>
      {
        var xml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xml), includeControllerXmlComments: true);
      });

      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });

      app.UseRouting();
      app.UseCors("CorsPolicy");

      app.UseAuthorization();

      app.UseEndpoints(endpoints => endpoints
          .MapControllers()
          .RequireCors("CorsPolicy"));
      }
  }
}
    