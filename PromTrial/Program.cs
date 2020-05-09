using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Prometheus.DotNetRuntime;

namespace PromTrial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enabling prometheus-net.DotNetStats...");
            DotNetRuntimeStatsBuilder.Default().StartCollecting();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
