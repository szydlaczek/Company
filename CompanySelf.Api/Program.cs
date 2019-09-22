using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CompanySelf.Api
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            var webHost = WebHost.CreateDefaultBuilder(args)
            .UseUrls($"http://localhost:{config.GetValue<int>("Host:Port")}")
            .UseKestrel()
            .UseStartup<Startup>();

            return webHost;

        }
    }
}