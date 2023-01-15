namespace Modis.Twitter.Domain;

using Microsoft.Extensions.DependencyInjection;

using Modis.Twitter.Domain.Abstractions;
using Modis.Twitter.Domain.Service;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTwitterDomainServices(this IServiceCollection services)
    {
        return services.AddTransient<ITwitterStreamWorker, TwitterStreamWorker>();
    }
}