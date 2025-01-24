using ObservablePipelines;
using ObservablePipelines.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for configuring observable pipelines in an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IPipelineBuilder"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        /// <returns>The modified <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddObservablePipelines(this IServiceCollection services)
            => services
                .AddTransient<IServiceCollection>(_ => services)
                .AddTransient<IPipelineBuilder, PipelineBuilder>();
    }

}