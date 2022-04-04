namespace JxtauBlazor.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        { 
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => {
                webBuilder.UseStaticWebAssets();
                webBuilder.UseStartup<Startup>();
            });
        }
            
    }
}