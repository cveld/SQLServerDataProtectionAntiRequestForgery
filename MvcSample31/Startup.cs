using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MvcSample
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddAntiforgery(options => options.HeaderName= "RequestVerificationToken");
            services.AddApplicationInsightsTelemetry();
            services.AddLogging(logging =>
            {
                logging.AddConsole(); // options => options.LogToStandardErrorThreshold = Enum.Parse(typeof(LogLevel),  Configuration.GetSection("Logging").ToString());
                logging.AddDebug();
            });
        //    services.AddDataProtection()
        //.PersistKeysToFileSystem(new DirectoryInfo(@"Z:\Te2mp\dataprotection\"));
            // Add a DbContext to store your Database Keys
            services.AddDbContext<MyKeysContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyKeysConnection")));

            // using Microsoft.AspNetCore.DataProtection;
            services.AddDataProtection()
                .PersistKeysToDbContext<MyKeysContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
