using ObservablePipelines;
using ObservablePipelines.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IPipelineBuilder"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddObservablePipelines(this IServiceCollection services)
            => services
                .AddTransient<IServiceCollection>(_ => services)
                .AddTransient<IPipelineBuilder, PipelineBuilder>();
    }
}