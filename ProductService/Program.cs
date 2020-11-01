using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProductService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            // IWebHostEnvironment ctx = null;
            var host = WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) => {
                    config
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("hosting.json", optional: true)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddCommandLine(args);
                })
                //.UseKestrel(options =>
                //{

                //    options.Listen(System.Net.IPAddress.Loopback, 5031,
                //                listenOptions =>
                //                {
                //                    listenOptions.UseHttps("insurance.microservices.pfx", "frsglobal77");
                //                });
                //})
                .UseStartup<Startup>();
            return host;
        }
    }
}
