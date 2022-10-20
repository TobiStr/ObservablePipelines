using Microsoft.Extensions.DependencyInjection;
using System;

namespace ObservablePipelines
{
    public interface IPipelineConfigurationBuilder
    {
        IPipelineConfigurationBuilder Add<TConfiguration>(TConfiguration configuration) where TConfiguration : class;

        IPipelineConfigurationBuilder Add<TConfiguration>(
            Func<IServiceCollection, TConfiguration> configurationFactory
        ) where TConfiguration : class;
    }
}