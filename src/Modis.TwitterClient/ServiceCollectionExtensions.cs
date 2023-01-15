namespace Modis.TwitterClient;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Modis.TwitterClient.Abstractions;

public static class ServiceCollectionExtensions
{
    private const string TwitterSectionName = "TwitterApi";
    public static IServiceCollection AddTwitterClient(this IServiceCollection services, IConfiguration configuration)
    {
        var bearToken = configuration[$"{TwitterSectionName}:BearToken"];
        var streamUrl = configuration[$"{TwitterSectionName}:StreamUrl"];

        if (string.IsNullOrEmpty(bearToken))
            throw new ArgumentException("Invalid configuration, please provide 'BearToken' in 'TwitterApi' section in appsettings.json file or as environment variable");

        if (string.IsNullOrEmpty(streamUrl))
            throw new ArgumentException("Invalid configuration, please provide Twitter streaming end-point in 'TwitterApi' section in appsettings.json file or as environment variable");


        services.Configure<TwitterSettings>(options => {
                options.BearToken = bearToken;
                options.StreamUrl = streamUrl;
            });

        services.AddTransient<ITwitterClient, TwitterClient>();
        return services;
    }
}