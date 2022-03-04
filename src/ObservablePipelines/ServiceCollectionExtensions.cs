using ObservablePipelines;
using ObservablePipelines.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddObservablePipelines(this IServiceCollection services)
            => services
                .AddTransient<IServiceCollection>(_ => services)
                .AddTransient<IPipelineBuilder, PipelineBuilder>();
    }
}