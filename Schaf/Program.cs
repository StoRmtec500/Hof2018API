using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Schaf
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .UseUrls("https://localhost:8843", "https://remote.kuenz.co.at:8843/hofuebersicht/api", "https://remote.kuenz.co.at:8843", "https://10.1.0.237:8843", "https://localhost:5000", "http://10.1.0.6:8843")
                .UseIISIntegration();
    }
}
