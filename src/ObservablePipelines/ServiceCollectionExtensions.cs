using ObservablePipelines;
using ObservablePipelines.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IPipelineBuilder"/> to the <see cref="IServiceCollection"/>.
        /// When you want each Pipeline to build its services on a clone of the IServiceCollection, enable "cloneServiceCollection".
        /// </summary>
        /// <param name="services"></param>
        /// <param name="cloneServiceCollection"></param>
        /// <remarks>When you are cloning the ServiceCollection, a singleton may be instantiated for each pipeline separately.</remarks>
        public static IServiceCollection AddObservablePipelines(this IServiceCollection services, bool cloneServiceCollection = false)
            => services
                .AddTransient<IServiceCollection>(_ => services)
                .AddSingleton(new PipelineBuilderOptions(cloneServiceCollection))
                .AddTransient<IPipelineBuilder, PipelineBuilder>();
    }
}