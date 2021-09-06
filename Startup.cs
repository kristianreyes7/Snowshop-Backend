using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SnowShop.Models; //look for models
using Microsoft.EntityFrameworkCore; //using entity framework
using Microsoft.AspNetCore.Cors;
namespace Snowshop
{
    public class Startup
    {
        //constructor: grabbing the configuration obj that will grab vars
            //from apps
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //the prop to receive the config obj
        public IConfiguration Configuration{ get; }

        //method that gets called at runtime.  add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            //collects all of controllers for routing
            services.AddControllers();
            //add cors with defaul policy and middleware
            services.AddCors();
            //saves the connection string appsettings.json as a var
            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            //register the db context as a service
            services.AddDbContext<SnowboardContext>(opt => opt.UseNpgsql(connectionString));

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Snowshop", Version = "v1"});
            });
        }

        //called at runtime. used to configure http request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Snowshop v1"));
            }
            //forces site to redirect to https
            // app.UseHttpsRedirection();
            app.UseRouting(); //enables writing
            app.UseAuthorization(); //enables authorization
             app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()); //enables cors   
           

            app.UseEndpoints(endpoints => 
            {
                //enable attrb routing
                endpoints.MapControllers();
                //enable pattern matching
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{URLParam?}"
                );
            });
        }    
    }
}