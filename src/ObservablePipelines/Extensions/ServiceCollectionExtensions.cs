using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ObservablePipelines.Extensions
{
    /// <summary>
    /// Provides internal extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    internal static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Creates a new <see cref="IServiceCollection"/> by cloning the current collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to clone.</param>
        /// <returns>A new <see cref="IServiceCollection"/> instance containing the same services.</returns>
        public static IServiceCollection Clone(this IServiceCollection services) {
            var newServiceCollection = new ServiceCollection();

            foreach (var service in services) {
                newServiceCollection.Add(service);
            }

            return newServiceCollection;
        }
    }

}