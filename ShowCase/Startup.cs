using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShowCase.Examples.Logic;
using ShowCase.Examples.Models.Database;
using ShowCase.Examples.Repository;
using ShowCase.Exceptions.Handler;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System;
using System.IO;

namespace ShowCase
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

            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            var connectionString = Configuration["ConnectionStrings:RawDb"];
            services.AddDbContext<ShowCaseDbContext>(options => options.UseSqlite(connectionString));

            services.AddTransient<IExamplesLogic, ExamplesLogic>();
            services.AddTransient<IExamplesRepository, ExamplesRepository>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1"
                    , Title = "Example API"
                    , TermsOfService = new System.Uri("https://www.example.com/")
                    , Contact = new OpenApiContact
                    {
                        Name = "Example GmbH"
                        , Email = "support@example.com"
                        , Url = new System.Uri("https://www.example.com/")
                    }

                });
                // Set documentation path - extra complicated to make it generic                          
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });              
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });

            app.UseExceptionHandler(ex => ex.Run(ExceptionHandler.Handle));

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<ShowCaseDbContext>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Database.Migrate();
        }

        private IDbConnecctionProfile GetDbConnection()
        {
            var dbConnection = new DbConnecctionProfile()
            {
                ConnectionString = Configuration.GetConnectionString("ConnectionStrings:ShowCaseDbContext")
            };

            return dbConnection;
        }
    }
}
