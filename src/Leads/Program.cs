using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Leads;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().RunWithGraphQLCommands(args);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}