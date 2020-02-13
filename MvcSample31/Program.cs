using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MvcSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()                
            //    .Build();

            //host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
        return
            Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
        }
    }
}
