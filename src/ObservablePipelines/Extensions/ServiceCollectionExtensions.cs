using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ObservablePipelines.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection Clone(this IServiceCollection services) {
            var newServiceCollection = new ServiceCollection();

            foreach (var service in services) {
                newServiceCollection.Add(service);
            }

            return newServiceCollection;
        }
    }
}