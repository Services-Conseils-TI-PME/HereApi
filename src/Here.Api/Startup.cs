using Here.Configuration;
using Here.Geocoder;
using Here.Route;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Here
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration env)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services) //, IWebHostEnvironment env
        {
            services.AddControllers(options =>
                {
                    options.RespectBrowserAcceptHeader = true; // false by default
                })
            .AddXmlSerializerFormatters()
            .AddJsonOptions(options =>
                {
                    // Use the default property (Pascal) casing.
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.WriteIndented = true;
                });
            //.AddNewtonsoftJson(options =>
            //    {
            //        // Use the default property (Pascal) casing
            //        //options.SerializerSettings.ContractResolver = new DefautlContractResolver();
            //        options.UseCamelCasing(true);
            //        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //    });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Here Middleware", Version = "v1" });
            });

            services.AddScoped<IHereConfig, HereConfig>();
            services.AddScoped<IHereRouteTruckService, HereRouteTruckService>();
            services.AddScoped<IHereGeocodeService, HereGeocodeService>();

            //if (!env.IsDevelopment())
            //{
            //    services.AddHttpsRedirection(options =>
            //    {
            //        options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            //        options.HttpsPort = 443;
            //    });

            //    services.AddHsts(options =>
            //    {
            //        options.Preload = true;
            //        options.IncludeSubDomains = true;
            //        options.MaxAge = TimeSpan.FromDays(60);
            //        options.ExcludedHosts.Add("example.com");
            //        options.ExcludedHosts.Add("www.example.com");
            //    });
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseHsts();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}