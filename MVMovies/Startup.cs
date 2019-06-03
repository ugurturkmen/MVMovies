using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace MVMovies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            string logConfigFile = configuration.GetValue<string>("AppSettings:logConfigFile");
            LogManagement.ILogger logger = new LogManagement.Logger();
            logger.add(logConfigFile, "Application is started");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ////////////////////////
            /////AUTHENTICATION/////
            ////////////////////////
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Home.html";
        });

            var ConnectionString = Configuration.GetConnectionString("MsSql_MVMovies");
            services.AddDbContext<DAO.MVMoviesContext>(options => options.UseSqlServer(ConnectionString));


            /////////////////
            /////SWAGGER/////
            /////////////////
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "MVMovies API", Version = "v1" });
            });

            ////////////////////////
            /////HOSTED SERVİCE/////
            ////////////////////////
            services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, HostedService.CheckApiMovie>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /////////////////
            /////SWAGGER/////
            /////////////////
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MVMovies API V1");
            });


            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
