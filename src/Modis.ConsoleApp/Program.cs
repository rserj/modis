using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

using Modis.Twitter.Domain;
using Modis.Twitter.Domain.Abstractions;
using Modis.TwitterClient;
public class Program
{
    static Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var workerInstance = host.Services.GetRequiredService<ITwitterStreamWorker>();
        workerInstance.WatchTwitterStream(CancellationToken.None);
        return host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    configuration
                        
                        .AddEnvironmentVariables() // add Env variables provider, in order to override Twitter credentials configuration for production
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
            .ConfigureServices((builder, services) =>
                {
                    services
                        .AddMemoryCache()
                        .AddTwitterClient(builder.Configuration)
                        .AddTwitterDomainServices();
                })
            .ConfigureLogging((_, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddSimpleConsole(options =>
                        {
                            options.IncludeScopes = false;
                            options.ColorBehavior = LoggerColorBehavior.Enabled;
                            options.UseUtcTimestamp = false;
                        });
                });
}